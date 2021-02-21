using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public class ReadFileLogic : LogicBase
    {

        public List<BloodGlucose> listBloodGlucoseToday { set; get; }
        public List<PulseAndOxygen> listPulseAndOxygenToday { set; get; }

        public List<BloodGlucose> listBloodGlucoseLast7Days { set; get; }
        public List<PulseAndOxygen> listPulseAndOxygenLast7Days { set; get; }

        public List<BloodGlucose> listBloodGlucoseLast30Days { set; get; }
        public List<PulseAndOxygen> listPulseAndOxygenLast30Days { set; get; }

        public ReadFileLogic()
        {
        }

        public ReadFileLogic(string fName, string pName, string fPname) : base(fName,pName,fPname)
        {
        }

        public void SetupListsByDay()
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;

            DateTime now = DateTime.Now;
            DateTime nowMinus7;
            DateTime nowMinus30;

            string formattedDate = "";

            try
            {
                nowMinus7 = now.AddDays(-7);
                nowMinus30 = now.AddDays(-30);

                formattedDate = now.ToString("yyyyMMdd");

                listBloodGlucoseToday = listBloodGlucose.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"),formattedDate)>=0).ToList();

                listPulseAndOxygenToday = listPulseAndOxygen.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"), formattedDate) >= 0).ToList();


                formattedDate = nowMinus7.ToString("yyyyMMdd");

                listBloodGlucoseLast7Days = listBloodGlucose.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"), formattedDate) >= 0).ToList();

                listPulseAndOxygenLast7Days = listPulseAndOxygen.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"), formattedDate) >= 0).ToList();

                formattedDate = nowMinus30.ToString("yyyyMMdd");

                listBloodGlucoseLast30Days = listBloodGlucose.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"), formattedDate) >= 0).ToList();

                listPulseAndOxygenLast30Days = listPulseAndOxygen.Where(x => string.Compare(x.DateRead.ToString("yyyyMMdd"), formattedDate) >= 0).ToList();

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

                throw new Exception(messageText);

            }
        }

        public void ReadFile()
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;
            StreamReader streamReader = null;
            string line = "";
            BloodGlucose bloodGlucose = null;
            PulseAndOxygen pulseAndOxygen = null;
            try
            {
                SetupLists();

                GetFormattedFileName();

                if (File.Exists(FilePathName) == true)
                {
                    
                    streamReader = new StreamReader(FilePathName, Encoding.ASCII);

                    while (streamReader.EndOfStream == false)
                    {
                        line = streamReader.ReadLine();

                        if (string.IsNullOrEmpty(line) == false)
                        {
                            if (line.StartsWith("PII") == true)
                            {
                                this.personallyIdentifiableInformation = ConvertLogic.ConvertPersonallyIdentifiableInformation(line,'|');

                            }
                            if (line.StartsWith("PO") == true)
                            {
                                pulseAndOxygen = ConvertLogic.ConvertPulseAndOxygen(line, '|');
                                if (pulseAndOxygen != null)
                                {
                                    this.listPulseAndOxygen.Add(pulseAndOxygen);
                                }
                            }
                            if (line.StartsWith("BG") == true)
                            {
                                bloodGlucose = ConvertLogic.ConvertBloodGlucose(line, '|');
                                if (bloodGlucose != null)
                                {
                                    this.listBloodGlucose.Add(bloodGlucose);
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

                throw new Exception(messageText);

            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader = null;
                }
            }
        }

    }
}
