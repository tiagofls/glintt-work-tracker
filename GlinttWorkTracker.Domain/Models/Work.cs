using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public class Work : Entity
    {
        public string GlinttApp { get; set; }
        public string Description { get; set; }
        public string Epic { get; set; }
        public int IdIssue { get; set; }
        public DateTime Date { get; set; }
        public List<NuGetUpdates> NuGetUpdates { get; set; }
        public List<DBScripts> DBScripts { get; set; }
        public List<DataBaseChanges> DataBaseChanges { get; set; }
        public List<CodeChanges> CodeChanges { get; set; }
    }
}
