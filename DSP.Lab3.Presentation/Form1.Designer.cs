
namespace DSP.Lab3.Presentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.SmoothingGroupBox = new System.Windows.Forms.GroupBox();
            this.SmoothingComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ImageSmoothingGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageSmoothingComboBox = new System.Windows.Forms.ComboBox();
            this.WindowSizeComboBox = new System.Windows.Forms.ComboBox();
            this.WindowSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.SmoothingGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ImageSmoothingGroupBox.SuspendLayout();
            this.WindowSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmoothingGroupBox
            // 
            this.SmoothingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SmoothingGroupBox.Controls.Add(this.SmoothingComboBox);
            this.SmoothingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SmoothingGroupBox.Location = new System.Drawing.Point(17, 22);
            this.SmoothingGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SmoothingGroupBox.Name = "SmoothingGroupBox";
            this.SmoothingGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SmoothingGroupBox.Size = new System.Drawing.Size(376, 75);
            this.SmoothingGroupBox.TabIndex = 4;
            this.SmoothingGroupBox.TabStop = false;
            this.SmoothingGroupBox.Text = "Вид сглаживания";
            // 
            // SmoothingComboBox
            // 
            this.SmoothingComboBox.FormattingEnabled = true;
            this.SmoothingComboBox.Items.AddRange(new object[] {
            "Параболическое",
            "Скользящим усреднением",
            "Медианной фильтрацией"});
            this.SmoothingComboBox.Location = new System.Drawing.Point(7, 30);
            this.SmoothingComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SmoothingComboBox.Name = "SmoothingComboBox";
            this.SmoothingComboBox.Size = new System.Drawing.Size(355, 33);
            this.SmoothingComboBox.TabIndex = 6;
            this.SmoothingComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(400, 22);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 431);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1133, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сигналы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(23, 17);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Исходный сигнал";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Сглаженный сигнал";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1032, 364);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Сигналы";
            this.chart1.Titles.Add(title1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1133, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Фазовый спектр";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(7, 15);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Исходный сигнал";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series4.Legend = "Legend1";
            series4.Name = "Сглаженный сигнал";
            series4.YValuesPerPoint = 4;
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(1036, 368);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Фазовый спектр";
            this.chart2.Titles.Add(title2);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chart3);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1133, 393);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Амплитудный спектр";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(31, 26);
            this.chart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart3.Name = "chart3";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Исходный сигнал";
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.Name = "Сглаженный сигнал";
            series6.YValuesPerPoint = 4;
            this.chart3.Series.Add(series5);
            this.chart3.Series.Add(series6);
            this.chart3.Size = new System.Drawing.Size(1012, 367);
            this.chart3.TabIndex = 0;
            this.chart3.Text = "chart3";
            title3.Name = "Title1";
            title3.Text = "Амплитудный спектр";
            this.chart3.Titles.Add(title3);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1133, 393);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Images";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(517, 342);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load Pic...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(657, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(437, 370);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 370);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ImageSmoothingGroupBox
            // 
            this.ImageSmoothingGroupBox.Controls.Add(this.ImageSmoothingComboBox);
            this.ImageSmoothingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImageSmoothingGroupBox.Location = new System.Drawing.Point(12, 103);
            this.ImageSmoothingGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImageSmoothingGroupBox.Name = "ImageSmoothingGroupBox";
            this.ImageSmoothingGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImageSmoothingGroupBox.Size = new System.Drawing.Size(383, 75);
            this.ImageSmoothingGroupBox.TabIndex = 6;
            this.ImageSmoothingGroupBox.TabStop = false;
            this.ImageSmoothingGroupBox.Text = "Вид сглаживания изображения:";
            // 
            // ImageSmoothingComboBox
            // 
            this.ImageSmoothingComboBox.FormattingEnabled = true;
            this.ImageSmoothingComboBox.Items.AddRange(new object[] {
            "Скользящее усреднение",
            "Размытие Гаусса",
            "Медианный фильтр",
            "Фильтр Собеля"});
            this.ImageSmoothingComboBox.Location = new System.Drawing.Point(5, 30);
            this.ImageSmoothingComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImageSmoothingComboBox.Name = "ImageSmoothingComboBox";
            this.ImageSmoothingComboBox.Size = new System.Drawing.Size(361, 33);
            this.ImageSmoothingComboBox.TabIndex = 7;
            this.ImageSmoothingComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // WindowSizeComboBox
            // 
            this.WindowSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowSizeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WindowSizeComboBox.FormattingEnabled = true;
            this.WindowSizeComboBox.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15",
            "17"});
            this.WindowSizeComboBox.Location = new System.Drawing.Point(12, 31);
            this.WindowSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WindowSizeComboBox.Name = "WindowSizeComboBox";
            this.WindowSizeComboBox.Size = new System.Drawing.Size(361, 33);
            this.WindowSizeComboBox.TabIndex = 7;
            this.WindowSizeComboBox.TextChanged += new System.EventHandler(this.WindowSizeComboBox_TextChanged);
            // 
            // WindowSizeGroupBox
            // 
            this.WindowSizeGroupBox.Controls.Add(this.WindowSizeComboBox);
            this.WindowSizeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WindowSizeGroupBox.Location = new System.Drawing.Point(12, 199);
            this.WindowSizeGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WindowSizeGroupBox.Name = "WindowSizeGroupBox";
            this.WindowSizeGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WindowSizeGroupBox.Size = new System.Drawing.Size(381, 108);
            this.WindowSizeGroupBox.TabIndex = 9;
            this.WindowSizeGroupBox.TabStop = false;
            this.WindowSizeGroupBox.Text = "Размер окна:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1549, 465);
            this.Controls.Add(this.WindowSizeGroupBox);
            this.Controls.Add(this.ImageSmoothingGroupBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SmoothingGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Алгоритмы сглаживания";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SmoothingGroupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ImageSmoothingGroupBox.ResumeLayout(false);
            this.WindowSizeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox SmoothingGroupBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox SmoothingComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox ImageSmoothingGroupBox;
        private System.Windows.Forms.ComboBox ImageSmoothingComboBox;
        private System.Windows.Forms.ComboBox WindowSizeComboBox;
        private System.Windows.Forms.GroupBox WindowSizeGroupBox;
    }
}

