using GlinttWorkTracker.Domain;
using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Domain.Repositories;
using GlinttWorkTracker.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Infrastructure.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(GlinttWorkTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Work>> GetAll()
        {
            return await _dbContext.Set<Work>().ToListAsync();
        }
        public override async Task<bool> Add(Work work)
        {
            if (work.Id == 0)
            {
                this.Create(work);
                return true;
            }
            return false;
        }
        public override async Task<bool> Update_(Work work)
        {
            if (work.Id != 0)
            {
                this.Update(work);
                return true;
            }
            return false;
        }
        public override async Task<bool> Delete(Work work)
        {
            if (work.Id != 0)
            {
                this.Remove(work);
                return true;
            }
            return false;
        }
        public override async Task<Work> FindById(string id)
        {
            return this.GetById(int.Parse(id));
        }
    }
}
