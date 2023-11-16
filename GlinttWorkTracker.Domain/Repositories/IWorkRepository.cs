using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Repositories
{
    public interface IWorkRepository : IRepository<Work>
    {
        Task<Work> UpsertAsync(Work e);
    }
}
