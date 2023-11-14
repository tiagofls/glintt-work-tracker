using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class CodeChanges
    {
        public string GlinttApp { get; set; }
        public string Project { get; set; }
        public string AuxProject { get; set; }
        public string File { get; set; }
    }
}
