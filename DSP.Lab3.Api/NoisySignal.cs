﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSP.Lab3.Api
{
    public class NoisySignal : Signal
    {
        public enum FilteringType 
        { 
            Sliding,
            Median,
            Parabolic 
        }

        double Amplitude;
        double Frequency;
        double Phase;
        public double[] parabolicSmoothedSignal, 
            medianSmoothedSignal, 
            slidingSmoothedSignal, 
            amplitudeSpectrum, 
            phaseSpectrum;
        public int numHarm;

        public NoisySignal(
            double amplitude,
            double frequency,
            double phase,
            int discrPoints,
            int windowSize)
        {
            Amplitude = amplitude;
            n = discrPoints;
            Frequency = frequency;
            Phase = phase;

            numHarm = n / 2;


            signal = GenerateSignal();
            parabolicSmoothedSignal = ParabolicSmoothing();
            medianSmoothedSignal = MedianSmoothing(windowSize);
            slidingSmoothedSignal = SlidingSmoothing(windowSize);
            sineSp = GetSineSpectrum(signal);
            cosineSp = GetCosineSpectrum(signal);
            amplSp = GetAmplitudeSpectrum(sineSp, cosineSp);
            phaseSp = GetPhaseSpectrum(sineSp, cosineSp);
            restSignal = RestoreSignal();
            nfSignal = RestoreNonPhasedSignal();
        }

        public void Operate(FilteringType filteringType)
        {
            double[] filteredSignal = null;
            switch (filteringType)
            {
                case FilteringType.Parabolic:
                    filteredSignal = parabolicSmoothedSignal;
                    break;
                case FilteringType.Median:
                    filteredSignal = medianSmoothedSignal;
                    break;
                case FilteringType.Sliding:
                    filteredSignal = slidingSmoothedSignal;
                    break;
                default:
                    break;
            }
            double[] sinSpectrum = GetSineSpectrum(filteredSignal);
            double[] cosSpectrum = GetCosineSpectrum(filteredSignal);
            amplitudeSpectrum = GetAmplitudeSpectrum(sinSpectrum, cosSpectrum);
            phaseSpectrum = GetPhaseSpectrum(sinSpectrum, cosSpectrum);
        }

        public double[] GetSineSpectrum(double[] signal)
        {
            double[] values = new double[numHarm];
            for (int j = 0; j < numHarm; j++)
            {
                double val = 0;
                for (int i = 0; i < n; i++)
                {
                    val += signal[i] * Math.Sin(2 * Math.PI * i * j / n);
                }
                values[j] = 2 * val / n;
            }
            return values;
        }

        public double[] GetCosineSpectrum(double[] signal)
        {
            double[] values = new double[numHarm];
            for (int j = 0; j < numHarm; j++)
            {
                double val = 0;
                for (int i = 0; i < n; i++)
                {
                    val += signal[i] * Math.Cos(2 * Math.PI * i * j / n);
                }
                values[j] = 2 * val / n;
            }
            return values;
        }

        public double[] GetAmplitudeSpectrum(double[] sineSp, double[] cosineSp)
        {
            double[] values = new double[numHarm];
            for (int j = 0; j < numHarm; j++)
            {
                values[j] = Math.Sqrt(Math.Pow(sineSp[j], 2) + Math.Pow(cosineSp[j], 2));
            }
            return values;
        }

        public double[] GetPhaseSpectrum(double[] sineSp, double[] cosineSp)
        {
            double[] values = new double[numHarm];
            for (int j = 0; j < numHarm; j++)
            {
                values[j] = Math.Atan2(sineSp[j], cosineSp[j]);
                if (amplSp[j] < 0.1)
                {
                    values[j] = 0;
                }
            }
            return values;
        }

        public double[] RestoreSignal()
        {
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                double val = 0;
                for (int j = 0; j < numHarm; j++)
                {
                    val += amplSp[j] * Math.Cos(2 * Math.PI * i * j / n - phaseSp[j]);
                }
                values[i] = val;
            }
            return values;
        }

        public double[] RestoreNonPhasedSignal()
        {
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                double val = 0;
                for (int j = 0; j < numHarm; j++)
                {
                    val += amplSp[j] * Math.Cos(2 * Math.PI * i * j / n);
                }
                values[i] = val;
            }
            return values;
        }

        public override double[] GenerateSignal()
        {
            double[] signalValues = new double[n];
            Random random = new Random();
            double B = Amplitude / 70;
            for (int i = 0; i < n; i++)
            {
                signalValues[i] = Amplitude * Math.Sin(2 * Math.PI * Frequency * i / n + Phase);
                double noise = 0;
                for (int j = 50; j <= 70; j++)
                {
                    noise += (random.Next(100000) % 2 == 0) 
                        ? (B * Math.Sin(2 * Math.PI * Frequency * i * j / n + Phase))
                        : (-B * Math.Sin(2 * Math.PI * i * j / n + Phase));
                }
                signalValues[i] += noise;
            }
            return signalValues;
        }

        public double[] ParabolicSmoothing()
        {
            double[] result = new double[n];
            for (int i = 7; i <= result.Length - 8; i++)
            {
                result[i] = (
                    - 3 * signal[i - 7]
                    - 6 * signal[i - 6]
                    - 5 * signal[i - 5]
                    + 3 * signal[i - 4]
                    + 21 * signal[i - 3]
                    + 46 * signal[i - 2]
                    + 67 * signal[i - 1]
                    + 74 * signal[i]
                    - 3 * signal[i + 7]
                    - 6 * signal[i + 6]
                    - 5 * signal[i + 5]
                    + 3 * signal[i + 4]
                    + 21 * signal[i + 3]
                    + 46 * signal[i + 2]
                    + 67 * signal[i + 1]) / 320;
            }
            return result;
        }

        public double[] SlidingSmoothing(int windowSize)
        {
            double[] result = (double[])signal.Clone();
            List<double> window = new List<double>();
            for (int i = 0; i < result.Length - windowSize; i++)
            {
                window.Clear();
                for (int j = i; j < i + windowSize; j++)
                {
                    window.Add(signal[j]);
                }
                double average = window.Sum() / windowSize;
                result[i + windowSize / 2] = average;
            }
            return result;
        }

        public double[] MedianSmoothing(int windowSize)
        {
            double[] result = (double[])signal.Clone();
            List<double> window = new List<double>();
            for (int i = 0; i < result.Length - windowSize; i++)
            {
                window.Clear();
                for (int j = i; j < i + windowSize; j++)
                {
                    window.Add(signal[j]);
                }
                window.Sort();
                result[i + windowSize / 2] = window[windowSize / 2];
            }
            return result;
        }

    }
}
