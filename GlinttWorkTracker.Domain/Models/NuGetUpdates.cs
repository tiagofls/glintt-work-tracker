using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class NuGetUpdates : Entity
    {
        public string NuGet {  get; set; }
        public string Where { get; set; }
    }
}
