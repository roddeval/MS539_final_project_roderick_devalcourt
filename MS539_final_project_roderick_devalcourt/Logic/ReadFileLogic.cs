using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public class ReadFileLogic
    {

        public ReadFileLogic()
        {
            Initialize();
        }

        public ReadFileLogic(ReadFileLogic readFileLogic)
        {
            Initialize();
            Copy(readFileLogic);
        }

        public void Initialize()
        {
            this.FileName = "";
            this.PathName = "";
            this.FilePathName = "";
        }

        public void Copy(ReadFileLogic readFileLogic)
        {
            if (readFileLogic != null)
            {
                this.FileName = readFileLogic.FileName;
                this.PathName = readFileLogic.PathName;
                this.FilePathName = readFileLogic.FilePathName;
            }
        }

        public string GetFormattedFileName()
        {
            string result = "";

            if ((string.IsNullOrEmpty(this.PathName) == false) &&
                (string.IsNullOrEmpty(this.FileName) == false))
            {
                result = PathName;
                if (result.EndsWith("\\") == false)
                {
                    result += "\\";
                }

                result += this.FileName;

                this.FilePathName = result;
            }
            else
            {
                this.FilePathName = "";
            }

            return this.FilePathName;

        }

        public void SetupLists()
        {
            this.personallyIdentifiableInformation = new PersonallyIdentifiableInformation();
            this.listBloodGlucose = new List<BloodGlucose>();
            this.listPulseAndOxygen = new List<PulseAndOxygen>();
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

        public PersonallyIdentifiableInformation personallyIdentifiableInformation { set; get; }
        public List<BloodGlucose> listBloodGlucose { set; get; }
        public List<PulseAndOxygen> listPulseAndOxygen { set; get; }
        public string FileName { set; get; }
        public string PathName { set; get; }
        public string FilePathName { set; get; }
    }
}
