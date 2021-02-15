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

        public ReadFileLogic()
        {
        }

        public ReadFileLogic(string fName, string pName, string fPname) : base(fName,pName,fPname)
        {
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
