using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_final_project_roderick_devalcourt.Entity
{
    public class Identifier
    {
        public Identifier()
        {
            Initialize();
        }
        public void Initialize()
        {
            Type = "";
            Id = Guid.Empty;
        }
        public void Copy(Identifier identifier)
        {
            if (identifier != null)
            {
                this.Type = identifier.Type;
                this.Id = identifier.Id;
            }
        }

        public string Type { set; get; }
        public Guid Id { set; get; }

    }
}
