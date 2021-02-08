using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_final_project_roderick_devalcourt.Entity
{
    public class PersonallyIdentifiableInformation : Identifier
    {
        public PersonallyIdentifiableInformation()
        {
            Initialize();
        }
        public new void Initialize()
        {
            base.Initialize();
            Id = Guid.NewGuid();
            this.Type = "PII";
            this.FirstName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = -1;
        }
        public void Copy(PersonallyIdentifiableInformation personallyIdentifiableInformation)
        {
            if (personallyIdentifiableInformation != null)
            {
                this.Id = personallyIdentifiableInformation.Id;
                this.Type = personallyIdentifiableInformation.Type;
                this.FirstName = personallyIdentifiableInformation.FirstName;
                this.LastName = personallyIdentifiableInformation.LastName;
                this.DateOfBirth = personallyIdentifiableInformation.DateOfBirth;
                this.Gender = personallyIdentifiableInformation.Gender;
            }
        }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth {set;get;}
        public int Gender { set; get; }
    }
}
