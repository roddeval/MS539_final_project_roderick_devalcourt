using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_final_project_roderick_devalcourt.Entity
{
    public class PulseAndOxygen : Identifier
    {
        public PulseAndOxygen()
        {
            Initialize();
        }
        public new void Initialize()
        {
            base.Initialize();
            Id = Guid.NewGuid();
            this.Type = "PO";
            this.PII_ID = Guid.Empty;
            this.Pulse = 0;
            this.Oxygen = 0M;
            this.DateRead = DateTime.Now;
            this.TimeRead = DateTime.Now;
        }
        public void Copy(PulseAndOxygen pulseAndOxygen)
        {
            if (pulseAndOxygen != null)
            {
                this.Id = pulseAndOxygen.Id;
                this.Type = pulseAndOxygen.Type;
                this.PII_ID = pulseAndOxygen.PII_ID;
                this.Pulse = pulseAndOxygen.Pulse;
                this.Oxygen = pulseAndOxygen.Oxygen;
                this.DateRead = pulseAndOxygen.DateRead;
                this.TimeRead = pulseAndOxygen.TimeRead;
            }
        }
        public Guid PII_ID { set; get; }
        public int Pulse { set; get; }
        public decimal Oxygen { set; get; }
        public DateTime DateRead { set; get; }
        public DateTime TimeRead { set; get; }
    }
}
