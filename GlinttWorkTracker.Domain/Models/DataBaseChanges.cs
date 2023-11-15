using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class DataBaseChanges : DatabaseData
    {
        public int Id { get; set; }
        public string Package { get; set; }
        public string Method { get; set; }
    }
}
