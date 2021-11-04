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

            Calculate(1, NoisySignal.FilteringType.Parabolic);
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

        private void Calculate(int frequency, NoisySignal.FilteringType ft)
        {
            NoisySignal hs = new NoisySignal(10, frequency, 0, 512);
            double[] fs = null;
            switch (ft)
            {
                case NoisySignal.FilteringType.Parabolic:
                    fs = hs.ps;
                    break;
                case NoisySignal.FilteringType.Median:
                    fs = hs.ms;
                    break;
                case NoisySignal.FilteringType.Sliding:
                    fs = hs.ss;
                    break;
                default:
                    break;
            }

            ClearCharts();

            for (int i = 0; i <= 359; i++)
            {
                targetCharts[0].Series[0].Points.AddXY(2 * Math.PI * i / 360, hs.signVal[i]);
                targetCharts[0].Series[1].Points.AddXY(2 * Math.PI * i / 360, fs[i]);
            }

            hs.Operate(ft);

            for (int i = 0; i <= 49; i++)
            {
                targetCharts[1].Series[0].Points.AddXY(i, hs.phaseSp[i]);
                targetCharts[1].Series[1].Points.AddXY(i, hs.phaseSpectrum[i]);
                targetCharts[2].Series[0].Points.AddXY(i, hs.amplSp[i]);
                targetCharts[2].Series[1].Points.AddXY(i, hs.amplitudeSpectrum[i]);
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

        private void Transform()
        {
            Bitmap finalImage = originImage;
            pictureBox2.Image = finalImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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

                ImageSmoothingComboBox.SelectedIndex = 0;
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
            switch (ImageSmoothingComboBox.SelectedIndex)
            {
                default: return;
            }
            Transform();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
