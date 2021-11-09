using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DSP.Lab3.Api;

namespace DSP.Lab3.Presentation
{
    public partial class MainForm : Form
    {
        Chart[] targetCharts;
        Bitmap originImage;

        public MainForm()
        {
            InitializeComponent();

            targetCharts = new Chart[3];
            targetCharts[0] = chart1;
            targetCharts[1] = chart2;
            targetCharts[2] = chart3;

            SmoothingGroupBox.Enabled = true;
            ImageSmoothingGroupBox.Enabled = false;
        }

        private void ClearCharts()
        {
            for (int i = 0; i <= 2; i++)
            {
                foreach (var j in targetCharts[i].Series)
                {
                    j.Points.Clear();
                }
            }
        }

        private void Calculate(int frequency, NoisySignal.FilteringType filteringType)
        {
            bool windowSizeFlag = Int32.TryParse(WindowSizeComboBox.Text, out int windowSize);
            if (!windowSizeFlag)
            {
                throw new Exception("Window size is not a number!");
            }

            NoisySignal signal = new NoisySignal(10, frequency, 0, 512, windowSize);
            double[] filteredSignal = null;
            switch (filteringType)
            {
                case NoisySignal.FilteringType.Parabolic:
                    filteredSignal = signal.parabolicSmoothedSignal;
                    break;
                case NoisySignal.FilteringType.Median:
                    filteredSignal = signal.medianSmoothedSignal;
                    break;
                case NoisySignal.FilteringType.Sliding:
                    filteredSignal = signal.slidingSmoothedSignal;
                    break;
                default:
                    break;
            }

            ClearCharts();

            for (int i = 0; i <= 359; i++)
            {
                targetCharts[0].Series[0].Points.AddXY(2 * Math.PI * i / 360, signal.signVal[i]);
                targetCharts[0].Series[1].Points.AddXY(2 * Math.PI * i / 360, filteredSignal[i]);
            }

            signal.Operate(filteringType);

            for (int i = 0; i <= 49; i++)
            {
                targetCharts[1].Series[0].Points.AddXY(i, signal.phaseSp[i]);
                targetCharts[1].Series[1].Points.AddXY(i, signal.phaseSpectrum[i]);
                targetCharts[2].Series[0].Points.AddXY(i, signal.amplSp[i]);
                targetCharts[2].Series[1].Points.AddXY(i, signal.amplitudeSpectrum[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SmoothingComboBox.SelectedIndex)
            {
                case 0:
                    Calculate(1, NoisySignal.FilteringType.Parabolic);
                    break;
                case 1:
                    Calculate(1, NoisySignal.FilteringType.Sliding);
                    break;
                case 2:
                    Calculate(1, NoisySignal.FilteringType.Median);
                    break;
                default: return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Выберите изображение";
            fileDialog.Filter = "Image File (*png; *jpg; *bmp;) | *png; *jpg; *bmp;";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                originImage = new Bitmap(fileDialog.FileName);
                pictureBox1.Image = originImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                ImageSmoothingComboBox.SelectedIndex = 1;
                SmoothingGroupBox.Enabled = false;
                ImageSmoothingGroupBox.Enabled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3 && pictureBox1.Image != null)
            {
                SmoothingGroupBox.Enabled = false;
                ImageSmoothingGroupBox.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 3 && pictureBox1.Image == null)
            {
                SmoothingGroupBox.Enabled = false;
                ImageSmoothingGroupBox.Enabled = false;
            }
            else
            {
                SmoothingGroupBox.Enabled = true;
                ImageSmoothingGroupBox.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageTransformator transformator;

            switch (ImageSmoothingComboBox.SelectedIndex)
            {
                case 0:
                    transformator = new BoxBlurImageTransformator();
                    break;
                case 1:
                    transformator = new GaussianBlurImageTransformator();
                    break;
                case 2:
                    transformator = new MedianFilterImageTransformator();
                    break;
                case 3:
                    transformator = new SobelFilterImageTransformator();
                    break;
                default: return;
            }
            Bitmap finalImage = transformator.Transform(originImage, 5);
            pictureBox2.Image = finalImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowSizeComboBox.SelectedIndex = 0;
            Calculate(1, NoisySignal.FilteringType.Parabolic);
        }

        private void WindowSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            Calculate(1, NoisySignal.FilteringType.Parabolic);
        }
    }
}
