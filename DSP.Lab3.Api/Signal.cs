using System;

namespace DSP.Lab3.Api
{
    public abstract class Signal
    {
        public int n;
        public double[] signal, restSignal, nfSignal;
        public double[] sineSp, cosineSp;
        public double[] amplSp, phaseSp;

        public double[] signVal { get { return signal; } }
        public double[] amplSpectrum { get { return amplSp; } }
        public double[] phaseSpectrum { get { return phaseSp; } }
        public double[] restoredSignal { get { return restSignal; } }
        public double[] restorednonphasedSignal { get { return nfSignal; } }

        public abstract double[] GenerateSignal();
    }
}
