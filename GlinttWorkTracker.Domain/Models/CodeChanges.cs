using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class CodeChanges : Entity
    {
        public string GlinttApp { get; set; }
        public string Project { get; set; }
        public string AuxProject { get; set; }
        public string File { get; set; }
    }
}
