using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public static class ConvertLogic
    {
        public static PersonallyIdentifiableInformation ConvertPersonallyIdentifiableInformation(string line, char delim)
        {
            PersonallyIdentifiableInformation personallyIdentifiableInformation = null;

            string[] words = null;

            Guid id = Guid.Empty;
            DateTime dt = DateTime.MinValue;
            Int32 val = 0;
            CultureInfo culture;
            DateTimeStyles styles = DateTimeStyles.None;

            culture = CultureInfo.CreateSpecificCulture("en-US");

            if (string.IsNullOrEmpty(line) == false)
            {
                words = line.Split(delim);

                if (words != null)
                {
                    if (words.Length == 6)
                    {
                        personallyIdentifiableInformation = new PersonallyIdentifiableInformation();
                        personallyIdentifiableInformation.Type = words[0];
                        if (Guid.TryParse(words[1], out id) == true)
                        {
                            personallyIdentifiableInformation.Id = id;
                        }
                        personallyIdentifiableInformation.FirstName = words[2];
                        personallyIdentifiableInformation.LastName = words[3];

                        if (DateTime.TryParse(words[4], culture, styles, out dt) == true)
                        {
                            personallyIdentifiableInformation.DateOfBirth = dt;
                        }
                        if (Int32.TryParse(words[5], out val) == true)
                        {
                            if ((val == 0) || (val == 1))
                            {
                                personallyIdentifiableInformation.Gender = val;
                            }
                        }
                    }
                }
            }

            return personallyIdentifiableInformation;
        }
        public static BloodGlucose ConvertBloodGlucose(string line, char delim)
        {
            BloodGlucose bloodGlucose = null;
            string[] words = null;

            Guid id = Guid.Empty;
            DateTime dt = DateTime.MinValue;
            Int32 val = 0;
            CultureInfo culture;
            DateTimeStyles styles = DateTimeStyles.None;

            culture = CultureInfo.CreateSpecificCulture("en-US");

            if (string.IsNullOrEmpty(line) == false)
            {
                words = line.Split(delim);

                if (words != null)
                {
                    if (words.Length == 6)
                    {

                        bloodGlucose = new BloodGlucose();
                        
                        bloodGlucose.Type = words[0];
                        
                        if (Guid.TryParse(words[1], out id) == true)
                        {
                            bloodGlucose.Id = id;
                        }
                        
                        if (Guid.TryParse(words[2], out id) == true)
                        {
                            bloodGlucose.PII_ID = id;
                        }

                        if (Int32.TryParse(words[3], out val) == true)
                        {
                            bloodGlucose.MGDL = val;
                        }

                        if (DateTime.TryParse(words[4], culture, styles, out dt) == true)
                        {
                            bloodGlucose.DateRead = dt;
                        }
                        
                        if (DateTime.TryParse(words[5], culture, styles, out dt) == true)
                        {
                            bloodGlucose.TimeRead = dt;
                        }
                    }
                }
            }

            return bloodGlucose;
        }
        public static PulseAndOxygen ConvertPulseAndOxygen(string line, char delim)
        {
            PulseAndOxygen pulseAndOxygen = null;
            string[] words = null;

            Guid id = Guid.Empty;
            DateTime dt = DateTime.MinValue;
            Int32 val = 0;
            Decimal dv = 0M;
            CultureInfo culture;
            DateTimeStyles styles = DateTimeStyles.None;

            culture = CultureInfo.CreateSpecificCulture("en-US");

            if (string.IsNullOrEmpty(line) == false)
            {
                words = line.Split(delim);

                if (words != null)
                {
                    if (words.Length == 7)
                    {

                        pulseAndOxygen = new PulseAndOxygen();

                        pulseAndOxygen.Type = words[0];

                        if (Guid.TryParse(words[1], out id) == true)
                        {
                            pulseAndOxygen.Id = id;
                        }

                        if (Guid.TryParse(words[2], out id) == true)
                        {
                            pulseAndOxygen.PII_ID = id;
                        }

                        if (Int32.TryParse(words[3], out val) == true)
                        {
                            pulseAndOxygen.Pulse = val;
                        }

                        if (Decimal.TryParse(words[4], out dv) == true)
                        {
                            pulseAndOxygen.Oxygen = dv;
                        }

                        if (DateTime.TryParse(words[5], culture, styles, out dt) == true)
                        {
                            pulseAndOxygen.DateRead = dt;
                        }

                        if (DateTime.TryParse(words[6], culture, styles, out dt) == true)
                        {
                            pulseAndOxygen.TimeRead = dt;
                        }

                    }
                }
            }

            return pulseAndOxygen;
        }

        public static string ConvertPersonallyIdentifiableInformationToString(PersonallyIdentifiableInformation personallyIdentifiableInformation)
        {
            string result = "";
            StringBuilder sb = null;
            if (personallyIdentifiableInformation != null)
            {

                sb = new StringBuilder();
                sb.Append("Id: ");
                sb.Append(personallyIdentifiableInformation.Id.ToString());
                sb.Append(" ");
                sb.Append("Type: ");
                sb.Append(personallyIdentifiableInformation.Type);
                sb.Append(" ");
                sb.Append("First Name: ");
                sb.Append(personallyIdentifiableInformation.FirstName);
                sb.Append(" ");
                sb.Append("Last Name: ");
                sb.Append(personallyIdentifiableInformation.LastName);
                sb.Append(" ");
                sb.Append("Date of Birth: ");
                sb.Append(personallyIdentifiableInformation.DateOfBirth.ToString("MM/dd/yyyy"));
                sb.Append(" ");
                sb.Append("Gender: ");
                sb.Append(personallyIdentifiableInformation.Gender);
                result = sb.ToString();
            }
            return result;
        }

        public static string ConvertPersonallyIdentifiableInformationToString(PersonallyIdentifiableInformation personallyIdentifiableInformation,char delim)
        {
            string result = "";
            StringBuilder sb = null;
            if (personallyIdentifiableInformation != null)
            {

                sb = new StringBuilder();
                sb.Append(personallyIdentifiableInformation.Type);
                sb.Append(delim);
                sb.Append(personallyIdentifiableInformation.Id.ToString());
                sb.Append(delim);
                sb.Append(personallyIdentifiableInformation.FirstName);
                sb.Append(delim);
                sb.Append(personallyIdentifiableInformation.LastName);
                sb.Append(delim);
                sb.Append(personallyIdentifiableInformation.DateOfBirth.ToString("MM/dd/yyyy"));
                sb.Append(delim);
                sb.Append(personallyIdentifiableInformation.Gender);
                result = sb.ToString();
            }
            return result;
        }

        public static string ConvertBloodGlucoseToString(BloodGlucose bloodGlucose)
        {
            string result = "";
            StringBuilder sb = null;
            if (bloodGlucose != null)
            {
                sb = new StringBuilder();
                sb.Append("Id: ");
                sb.Append(bloodGlucose.Id.ToString());
                sb.Append(" ");
                sb.Append("Type: ");
                sb.Append(bloodGlucose.Type);
                sb.Append(" ");
                sb.Append("PII_ID: ");
                sb.Append(bloodGlucose.PII_ID.ToString());
                sb.Append(" ");
                sb.Append("MGDL: ");
                sb.Append(bloodGlucose.MGDL.ToString());
                sb.Append(" ");
                sb.Append("DateRead: ");
                sb.Append(bloodGlucose.DateRead.ToString("MM/dd/yyyy"));
                sb.Append(" ");
                sb.Append("TimeRead:");
                sb.Append(bloodGlucose.TimeRead.ToString("HH:mm:ss tt"));
                result = sb.ToString();

            }
            return result;
        }

        public static string ConvertBloodGlucoseToString(BloodGlucose bloodGlucose, char delim)
        {
            string result = "";
            StringBuilder sb = null;
            if (bloodGlucose != null)
            {
                sb = new StringBuilder();
                sb.Append(bloodGlucose.Type);
                sb.Append(delim);
                sb.Append(bloodGlucose.Id.ToString());
                sb.Append(delim);
                sb.Append(bloodGlucose.PII_ID.ToString());
                sb.Append(delim);
                sb.Append(bloodGlucose.MGDL.ToString());
                sb.Append(delim);
                sb.Append(bloodGlucose.DateRead.ToString("MM/dd/yyyy"));
                sb.Append(delim);
                sb.Append(bloodGlucose.TimeRead.ToString("HH:mm:ss tt"));
                result = sb.ToString();

            }
            return result;
        }

        public static string ConvertPulseAndOxygenToString(PulseAndOxygen pulseAndOxygen)
        {
            string result = "";
            StringBuilder sb = null;
            if (pulseAndOxygen != null)
            {
                sb = new StringBuilder();
                sb.Append("Id: ");
                sb.Append(pulseAndOxygen.Id.ToString());
                sb.Append(" ");
                sb.Append("Type: ");
                sb.Append(pulseAndOxygen.Type);
                sb.Append(" ");
                sb.Append("PII_ID: ");
                sb.Append(pulseAndOxygen.PII_ID.ToString());
                sb.Append(" ");
                sb.Append("Pulse");
                sb.Append(pulseAndOxygen.Pulse.ToString());
                sb.Append(" ");
                sb.Append("Oxygen");
                sb.Append(pulseAndOxygen.Oxygen.ToString());
                sb.Append(" ");
                sb.Append("DateRead: ");
                sb.Append(pulseAndOxygen.DateRead.ToString("MM/dd/yyyy"));
                sb.Append(" ");
                sb.Append("TimeRead:");
                sb.Append(pulseAndOxygen.TimeRead.ToString("HH:mm:ss tt"));
                result = sb.ToString();
            }
            return result;
        }

        public static string ConvertPulseAndOxygenToString(PulseAndOxygen pulseAndOxygen, char delim)
        {
            string result = "";
            StringBuilder sb = null;
            if (pulseAndOxygen != null)
            {
                sb = new StringBuilder();
                sb.Append(pulseAndOxygen.Type);
                sb.Append(delim);
                sb.Append(pulseAndOxygen.Id.ToString());
                sb.Append(delim);
                sb.Append(pulseAndOxygen.PII_ID.ToString());
                sb.Append(delim);
                sb.Append(pulseAndOxygen.Pulse.ToString());
                sb.Append(delim);
                sb.Append(pulseAndOxygen.Oxygen.ToString());
                sb.Append(delim);
                sb.Append(pulseAndOxygen.DateRead.ToString("MM/dd/yyyy"));
                sb.Append(delim);
                sb.Append(pulseAndOxygen.TimeRead.ToString("HH:mm:ss tt"));
                result = sb.ToString();
            }
            return result;
        }


    }
}
