namespace MS539_final_project_roderick_devalcourt
{
    partial class pulseAndOxygenChartForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbChartOptions = new System.Windows.Forms.GroupBox();
            this.rbLast30Days = new System.Windows.Forms.RadioButton();
            this.rbLast7Days = new System.Windows.Forms.RadioButton();
            this.rbToday = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbChartOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(465, 359);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(528, 275);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // gbChartOptions
            // 
            this.gbChartOptions.Controls.Add(this.rbLast30Days);
            this.gbChartOptions.Controls.Add(this.rbLast7Days);
            this.gbChartOptions.Controls.Add(this.rbToday);
            this.gbChartOptions.Location = new System.Drawing.Point(12, 293);
            this.gbChartOptions.Name = "gbChartOptions";
            this.gbChartOptions.Size = new System.Drawing.Size(447, 89);
            this.gbChartOptions.TabIndex = 1;
            this.gbChartOptions.TabStop = false;
            this.gbChartOptions.Text = "Chart Options";
            // 
            // rbLast30Days
            // 
            this.rbLast30Days.AutoSize = true;
            this.rbLast30Days.Checked = true;
            this.rbLast30Days.Location = new System.Drawing.Point(285, 34);
            this.rbLast30Days.Name = "rbLast30Days";
            this.rbLast30Days.Size = new System.Drawing.Size(87, 17);
            this.rbLast30Days.TabIndex = 2;
            this.rbLast30Days.TabStop = true;
            this.rbLast30Days.Text = "Last 30 Days";
            this.rbLast30Days.UseVisualStyleBackColor = true;
            this.rbLast30Days.Click += new System.EventHandler(this.rbLast30Days_Click);
            // 
            // rbLast7Days
            // 
            this.rbLast7Days.AutoSize = true;
            this.rbLast7Days.Location = new System.Drawing.Point(164, 34);
            this.rbLast7Days.Name = "rbLast7Days";
            this.rbLast7Days.Size = new System.Drawing.Size(81, 17);
            this.rbLast7Days.TabIndex = 1;
            this.rbLast7Days.Text = "Last 7 Days";
            this.rbLast7Days.UseVisualStyleBackColor = true;
            this.rbLast7Days.Click += new System.EventHandler(this.rbLast7Days_Click);
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.Location = new System.Drawing.Point(46, 34);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(55, 17);
            this.rbToday.TabIndex = 0;
            this.rbToday.Text = "Today";
            this.rbToday.UseVisualStyleBackColor = true;
            this.rbToday.Click += new System.EventHandler(this.rbToday_Click);
            // 
            // pulseAndOxygenChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 394);
            this.Controls.Add(this.gbChartOptions);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.addButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pulseAndOxygenChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pulse and Oxygen Chart";
            this.Load += new System.EventHandler(this.pulseAndOxygenChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbChartOptions.ResumeLayout(false);
            this.gbChartOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox gbChartOptions;
        private System.Windows.Forms.RadioButton rbLast30Days;
        private System.Windows.Forms.RadioButton rbLast7Days;
        private System.Windows.Forms.RadioButton rbToday;
    }
}