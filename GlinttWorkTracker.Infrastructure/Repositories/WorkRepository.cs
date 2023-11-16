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

        public override async Task<Work> UpsertAsync(Work e)
        {
            Work? f = null;
            Work existing = await this.FindByIdAsync(e.Id);

            if (existing == null)
            {
                if (e.Id == 0)
                {
                    f = this.Create(e);
                }
                else
                {
                    f = this.Update(e);
                }
            }
            else if (existing.Id == e.Id)
            {
                _dbContext.Entry(existing).State = EntityState.Detached;
                f = this.Update(e);
            }
            else
            {
                _dbContext.Entry(e).State = EntityState.Detached;
            }

            return f;
        }

        private Work Create(Work e)
        {
            e.Id = 1;
            _dbContext.Set<Work>().Add(e);
            _dbContext.SaveChanges();

            return e;
        }

        private Work Update(Work e)
        {
            _dbContext.Set<Work>().Update(e);
            _dbContext.SaveChanges();

            return e;
        }

    }
}
