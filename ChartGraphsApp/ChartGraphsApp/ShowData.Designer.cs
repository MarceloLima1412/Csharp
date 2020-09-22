namespace ChartGraphsApp
{
    partial class ShowData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowData));
            this.graficoSensor1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabelaSensor2 = new System.Windows.Forms.ListView();
            this.timeStamp2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.temperature2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.humidity2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.graficoSensor2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_connectBroker = new System.Windows.Forms.Button();
            this.tabelaSensor1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_disconnectBroker = new System.Windows.Forms.Button();
            this.pictureBoxOn = new System.Windows.Forms.PictureBox();
            this.pictureBoxOff = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graficoSensor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoSensor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOff)).BeginInit();
            this.SuspendLayout();
            // 
            // graficoSensor1
            // 
            chartArea1.Name = "ChartArea1";
            this.graficoSensor1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graficoSensor1.Legends.Add(legend1);
            this.graficoSensor1.Location = new System.Drawing.Point(415, 24);
            this.graficoSensor1.Name = "graficoSensor1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Temperature_1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Humidity_1";
            this.graficoSensor1.Series.Add(series1);
            this.graficoSensor1.Series.Add(series2);
            this.graficoSensor1.Size = new System.Drawing.Size(690, 214);
            this.graficoSensor1.TabIndex = 0;
            this.graficoSensor1.Text = "chart1";
            this.graficoSensor1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sensor 1 - Upstairs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sensor 2 - Downstairs";
            // 
            // tabelaSensor2
            // 
            this.tabelaSensor2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeStamp2,
            this.temperature2,
            this.humidity2});
            this.tabelaSensor2.FullRowSelect = true;
            this.tabelaSensor2.GridLines = true;
            this.tabelaSensor2.HideSelection = false;
            this.tabelaSensor2.Location = new System.Drawing.Point(28, 297);
            this.tabelaSensor2.Name = "tabelaSensor2";
            this.tabelaSensor2.Size = new System.Drawing.Size(327, 173);
            this.tabelaSensor2.TabIndex = 6;
            this.tabelaSensor2.UseCompatibleStateImageBehavior = false;
            this.tabelaSensor2.View = System.Windows.Forms.View.Details;
            // 
            // timeStamp2
            // 
            this.timeStamp2.Text = "TimeStamp";
            this.timeStamp2.Width = 96;
            // 
            // temperature2
            // 
            this.temperature2.Text = "Temperature";
            this.temperature2.Width = 91;
            // 
            // humidity2
            // 
            this.humidity2.Text = "Humidity";
            this.humidity2.Width = 136;
            // 
            // graficoSensor2
            // 
            chartArea2.Name = "ChartArea1";
            this.graficoSensor2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graficoSensor2.Legends.Add(legend2);
            this.graficoSensor2.Location = new System.Drawing.Point(415, 297);
            this.graficoSensor2.Name = "graficoSensor2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Temperature_2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Humidity_2";
            this.graficoSensor2.Series.Add(series3);
            this.graficoSensor2.Series.Add(series4);
            this.graficoSensor2.Size = new System.Drawing.Size(690, 214);
            this.graficoSensor2.TabIndex = 8;
            this.graficoSensor2.Text = "chart2";
            // 
            // btn_connectBroker
            // 
            this.btn_connectBroker.Location = new System.Drawing.Point(28, 485);
            this.btn_connectBroker.Name = "btn_connectBroker";
            this.btn_connectBroker.Size = new System.Drawing.Size(144, 34);
            this.btn_connectBroker.TabIndex = 9;
            this.btn_connectBroker.Text = "Connect ";
            this.btn_connectBroker.UseVisualStyleBackColor = true;
            this.btn_connectBroker.Click += new System.EventHandler(this.btn_connectBroker_Click);
            // 
            // tabelaSensor1
            // 
            this.tabelaSensor1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tabelaSensor1.FullRowSelect = true;
            this.tabelaSensor1.GridLines = true;
            this.tabelaSensor1.HideSelection = false;
            this.tabelaSensor1.Location = new System.Drawing.Point(28, 65);
            this.tabelaSensor1.Name = "tabelaSensor1";
            this.tabelaSensor1.Size = new System.Drawing.Size(327, 173);
            this.tabelaSensor1.TabIndex = 10;
            this.tabelaSensor1.UseCompatibleStateImageBehavior = false;
            this.tabelaSensor1.View = System.Windows.Forms.View.Details;
            this.tabelaSensor1.SelectedIndexChanged += new System.EventHandler(this.tabelaSensor1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TimeStamp";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Temperature";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Humidity";
            this.columnHeader3.Width = 135;
            // 
            // btn_disconnectBroker
            // 
            this.btn_disconnectBroker.Location = new System.Drawing.Point(211, 485);
            this.btn_disconnectBroker.Name = "btn_disconnectBroker";
            this.btn_disconnectBroker.Size = new System.Drawing.Size(144, 34);
            this.btn_disconnectBroker.TabIndex = 11;
            this.btn_disconnectBroker.Text = "Disconnect ";
            this.btn_disconnectBroker.UseVisualStyleBackColor = true;
            this.btn_disconnectBroker.Click += new System.EventHandler(this.btn_disconnectBroker_Click);
            // 
            // pictureBoxOn
            // 
            this.pictureBoxOn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOn.Image")));
            this.pictureBoxOn.Location = new System.Drawing.Point(177, 488);
            this.pictureBoxOn.Name = "pictureBoxOn";
            this.pictureBoxOn.Size = new System.Drawing.Size(27, 28);
            this.pictureBoxOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOn.TabIndex = 12;
            this.pictureBoxOn.TabStop = false;
            this.pictureBoxOn.Visible = false;
            // 
            // pictureBoxOff
            // 
            this.pictureBoxOff.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOff.Image")));
            this.pictureBoxOff.Location = new System.Drawing.Point(361, 488);
            this.pictureBoxOff.Name = "pictureBoxOff";
            this.pictureBoxOff.Size = new System.Drawing.Size(27, 28);
            this.pictureBoxOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOff.TabIndex = 13;
            this.pictureBoxOff.TabStop = false;
            this.pictureBoxOff.Visible = false;
            // 
            // ShowData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 531);
            this.Controls.Add(this.pictureBoxOff);
            this.Controls.Add(this.pictureBoxOn);
            this.Controls.Add(this.btn_disconnectBroker);
            this.Controls.Add(this.tabelaSensor1);
            this.Controls.Add(this.btn_connectBroker);
            this.Controls.Add(this.graficoSensor2);
            this.Controls.Add(this.tabelaSensor2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graficoSensor1);
            this.Name = "ShowData";
            this.Text = "Data Show";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowData_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.graficoSensor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoSensor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graficoSensor1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView tabelaSensor2;
        private System.Windows.Forms.ColumnHeader timeStamp2;
        private System.Windows.Forms.ColumnHeader temperature2;
        private System.Windows.Forms.ColumnHeader humidity2;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoSensor2;
        private System.Windows.Forms.Button btn_connectBroker;
        private System.Windows.Forms.ListView tabelaSensor1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_disconnectBroker;
        private System.Windows.Forms.PictureBox pictureBoxOn;
        private System.Windows.Forms.PictureBox pictureBoxOff;
    }
}