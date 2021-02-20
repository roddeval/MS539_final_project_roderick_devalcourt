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
    public partial class bloodGlucoseChartForm : Form
    {
        public bloodGlucoseChartForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            bloodGlucoseForm dlg = new bloodGlucoseForm();
            dlg.ShowDialog(this);
        }

        private void bloodGlucoseChartForm_Load(object sender, EventArgs e)
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
            ReadFileLogic readFileLogic = null;

            try
            {
                var chart = chart1.ChartAreas[0];
                chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                chart.AxisX.LabelStyle.Format = "HH:mm";
                chart.AxisX.LabelStyle.IsEndLabelVisible = true;

                chart1.Series.Clear();

                chart1.Series.Add("BloodGlucose");
                chart1.Series["BloodGlucose"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["BloodGlucose"].Color = Color.Green;
                chart1.Series["BloodGlucose"].XValueType = ChartValueType.Time;

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


                            foreach (BloodGlucose bloodGlucose in readFileLogic.listBloodGlucose)
                            {

                                chart1.Series["BloodGlucose"].Points.AddXY(bloodGlucose.TimeRead.ToOADate(), bloodGlucose.MGDL);


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

            }


        }

    }
}
