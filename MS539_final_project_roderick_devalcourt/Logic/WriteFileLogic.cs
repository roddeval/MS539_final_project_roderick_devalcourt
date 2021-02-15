using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public class WriteFileLogic : LogicBase
    {
        public WriteFileLogic()
        {
        }

        public WriteFileLogic(string fName, string pName, string fPname) : base(fName, pName, fPname)
        {
        }

        public void WriteFile()
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;
            StreamWriter writer = null;
            string line = "";
            char delim = '|';
            
            try
            {
                GetFormattedFileName();

                if (File.Exists(this.FilePathName) == true)
                {
                    File.Delete(this.FilePathName);
                }

                writer = new StreamWriter(this.FilePathName);

                if (this.personallyIdentifiableInformation != null)
                {
                    line = ConvertLogic.ConvertPersonallyIdentifiableInformationToString(this.personallyIdentifiableInformation,delim);
                    writer.WriteLine(line);
                }

                foreach (BloodGlucose bloodGlucose in this.listBloodGlucose)
                {
                    line = ConvertLogic.ConvertBloodGlucoseToString(bloodGlucose, delim);
                    writer.WriteLine(line);
                }

                foreach (PulseAndOxygen pulseAndOxygen in this.listPulseAndOxygen)
                {
                    line = ConvertLogic.ConvertPulseAndOxygenToString(pulseAndOxygen, delim);
                    writer.WriteLine(line);
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
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                    writer = null;
                }
            }

        }

    }
}
