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

        public async Task<IEnumerable<Issue>> GetAllIssues()
        {
            return await _dbContext.Set<Issue>().ToListAsync();
        }

        public Issue GetIssueById(int issueId)
        {
            return _dbContext.Set<Issue>().Find(issueId);
        }

        public Task<Work> UpsertAsync(Work e)
        {
            throw new NotImplementedException();
        }
    }
}
