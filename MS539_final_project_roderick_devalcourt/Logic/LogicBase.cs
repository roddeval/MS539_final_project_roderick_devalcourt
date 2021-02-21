using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public class LogicBase
    {

        public LogicBase()
        {
            Initialize();
        }

        public LogicBase(string fName, string pName, string fPname)
        {
            Initialize();
            this.FileName = fName;
            this.PathName = pName;
            this.FilePathName = fPname;
        }

        public virtual void Initialize()
        {
            this.FileName = "";
            this.PathName = "";
            this.FilePathName = "";
            SetupLists();
        }

        public void SetupLists()
        {
            this.personallyIdentifiableInformation = new PersonallyIdentifiableInformation();
            this.listBloodGlucose = new List<BloodGlucose>();
            this.listPulseAndOxygen = new List<PulseAndOxygen>();
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

        public string FileName { set; get; }
        public string PathName { set; get; }
        public string FilePathName { set; get; }

        public PersonallyIdentifiableInformation personallyIdentifiableInformation { set; get; }
        public List<BloodGlucose> listBloodGlucose { set; get; }
        public List<PulseAndOxygen> listPulseAndOxygen { set; get; }
    }
}
