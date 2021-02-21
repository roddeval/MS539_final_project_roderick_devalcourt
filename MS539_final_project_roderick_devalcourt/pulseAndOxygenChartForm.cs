using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MS539_final_project_roderick_devalcourt.Entity;
using MS539_final_project_roderick_devalcourt.Logic;
using System.Windows.Forms.DataVisualization.Charting;

namespace MS539_final_project_roderick_devalcourt
{
    public partial class pulseAndOxygenChartForm : Form
    {

        ReadFileLogic readFileLogic { set; get; }


        public pulseAndOxygenChartForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            pulseAndOxygenForm dlg = new pulseAndOxygenForm();
            dlg.ShowDialog(this);
        }

        private void pulseAndOxygenChartForm_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;
            string path = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.DefaultPath;
            string fileName = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.FileName;

            try
            {
                var chart = chart1.ChartAreas[0];
                chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                chart.AxisX.LabelStyle.Format = "HH:mm";
                chart.AxisX.LabelStyle.IsEndLabelVisible = true;

                chart1.Series.Clear();

                chart1.Series.Add("Pulse");
                chart1.Series["Pulse"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["Pulse"].Color = Color.Green;
                chart1.Series["Pulse"].XValueType = ChartValueType.Time;

                chart1.Series.Add("Oxygen");
                chart1.Series["Oxygen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["Oxygen"].Color = Color.Blue;
                chart1.Series["Oxygen"].XValueType = ChartValueType.Time;

                if ((string.IsNullOrEmpty(path) == false) && (string.IsNullOrEmpty(fileName) == false))
                {
                    readFileLogic = new ReadFileLogic();
                    if (readFileLogic != null)
                    {
                        readFileLogic.PathName = path;
                        readFileLogic.FileName = fileName;
                        readFileLogic.GetFormattedFileName();

                        if (File.Exists(readFileLogic.FilePathName) == true)
                        {
                            readFileLogic.ReadFile();
                            readFileLogic.SetupListsByDay();

                            if (readFileLogic.listPulseAndOxygenLast30Days != null)
                            {
                                foreach (PulseAndOxygen pulseAndOxygen in readFileLogic.listPulseAndOxygenLast30Days)
                                {



                                    chart1.Series["Pulse"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Pulse);
                                    chart1.Series["Oxygen"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Oxygen);


                                }
                            }
                        }

                    }
                }

            }
            catch (Exception exception)
            {
                stringBuilder = new StringBuilder();
                exceptionDetails = exception;

                while (exceptionDetails != null)
                {

                    messageText = "\r\nMessage: " + exceptionDetails.Message + "\r\nSource: " + exceptionDetails.Source + "\r\nStack Trace: " + exceptionDetails.StackTrace + "\r\n----------\r\n";

                    stringBuilder.Append(messageText);

                    exceptionDetails = exceptionDetails.InnerException;

                }

                messageText = stringBuilder.ToString();

                System.Diagnostics.Debug.WriteLine(messageText);
                MessageBox.Show(this, messageText, "Error");

            }


        }

        private void rbLast30Days_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            chart1.Series.Add("Pulse");
            chart1.Series["Pulse"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Pulse"].Color = Color.Green;
            chart1.Series["Pulse"].XValueType = ChartValueType.Time;

            chart1.Series.Add("Oxygen");
            chart1.Series["Oxygen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Oxygen"].Color = Color.Blue;
            chart1.Series["Oxygen"].XValueType = ChartValueType.Time;

            if (readFileLogic.listPulseAndOxygenLast30Days != null)
            {
                foreach (PulseAndOxygen pulseAndOxygen in readFileLogic.listPulseAndOxygenLast30Days)
                {



                    chart1.Series["Pulse"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Pulse);
                    chart1.Series["Oxygen"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Oxygen);


                }
            }

        }

        private void rbLast7Days_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            chart1.Series.Add("Pulse");
            chart1.Series["Pulse"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Pulse"].Color = Color.Green;
            chart1.Series["Pulse"].XValueType = ChartValueType.Time;

            chart1.Series.Add("Oxygen");
            chart1.Series["Oxygen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Oxygen"].Color = Color.Blue;
            chart1.Series["Oxygen"].XValueType = ChartValueType.Time;

            if (readFileLogic.listPulseAndOxygenLast7Days != null)
            {
                foreach (PulseAndOxygen pulseAndOxygen in readFileLogic.listPulseAndOxygenLast7Days)
                {

                    chart1.Series["Pulse"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Pulse);
                    chart1.Series["Oxygen"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Oxygen);


                }
            }
        }

        private void rbToday_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            chart1.Series.Add("Pulse");
            chart1.Series["Pulse"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Pulse"].Color = Color.Green;
            chart1.Series["Pulse"].XValueType = ChartValueType.Time;

            chart1.Series.Add("Oxygen");
            chart1.Series["Oxygen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Oxygen"].Color = Color.Blue;
            chart1.Series["Oxygen"].XValueType = ChartValueType.Time;

            if (readFileLogic.listPulseAndOxygenToday != null)
            {
                foreach (PulseAndOxygen pulseAndOxygen in readFileLogic.listPulseAndOxygenToday)
                {

                    chart1.Series["Pulse"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Pulse);
                    chart1.Series["Oxygen"].Points.AddXY(pulseAndOxygen.TimeRead.ToOADate(), pulseAndOxygen.Oxygen);


                }
            }
        }
    }
}
