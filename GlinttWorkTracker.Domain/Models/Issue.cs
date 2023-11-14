using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public enum Type { Story, Defect, Bug };
    public class Issue
    {
        public Type Type { get; set; }
    }
}
