using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class DBScripts : Entity
    {
        public string Database { get; set; }
        public string UserPwd { get; set; }
        public string Description { get; set; }
    }
}
