using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS539_final_project_roderick_devalcourt.Entity;

namespace MS539_final_project_roderick_devalcourt.Logic
{
    public abstract class Builder
    {
        public abstract void Construct(string path, 
                                       string fileName, 
                                       List<BloodGlucose> listBloodGlucose,
                                       List<PersonallyIdentifiableInformation> listPersonallyIdentifiableInformation,
                                       List<PulseAndOxygen> listPulseAndOxygen);
    }
}
