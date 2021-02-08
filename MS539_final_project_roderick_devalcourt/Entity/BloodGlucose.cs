using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_final_project_roderick_devalcourt.Entity
{
    public class BloodGlucose : Identifier
    {
        public BloodGlucose()
        {
            Initialize();
        }
        public new void Initialize()
        {
            base.Initialize();
            Id = Guid.NewGuid();
            this.Type = "BG";
            this.PII_ID = Guid.Empty;
            this.MGDL = 0M;
            this.DateRead = DateTime.Now;
            this.TimeRead = DateTime.Now;
        }
        public void Copy(BloodGlucose bloodGlucose)
        {
            if (bloodGlucose != null)
            {
                this.Id = bloodGlucose.Id;
                this.Type = bloodGlucose.Type;
                this.PII_ID = bloodGlucose.PII_ID;
                this.MGDL = bloodGlucose.MGDL;
                this.DateRead = bloodGlucose.DateRead;
                this.TimeRead = bloodGlucose.TimeRead;
            }
        }
        public Guid PII_ID { set; get; }
        public decimal MGDL { set; get; }
        public DateTime DateRead { set; get; }
        public DateTime TimeRead { set; get; }
    }
}
