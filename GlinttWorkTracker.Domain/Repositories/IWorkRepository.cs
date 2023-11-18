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
        Task<IEnumerable<Work>> GetAll();
        Task<bool> Add(Work work);
        Task<bool> Update_(Work work);
        Task<bool> Delete(Work work);
        Task<Work> FindById(string id);
    }
}
