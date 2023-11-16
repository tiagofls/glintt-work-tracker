using GlinttWorkTracker.Domain;
using GlinttWorkTracker.Domain.Repositories;
using GlinttWorkTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContextOptions<GlinttWorkTrackerDbContext> _options;
        private GlinttWorkTrackerDbContext _dbContext;

        public IWorkRepository WorkRepository
            => new WorkRepository(_dbContext);

        public UnitOfWork()
        {
            _dbContext = new GlinttWorkTrackerDbContext();
            _dbContext.Database.EnsureCreated();
            //_dbContext.Database.Migrate();
        }

        public UnitOfWork(DbContextOptions<GlinttWorkTrackerDbContext> options)
        {
            _options = options;
            _dbContext = new GlinttWorkTrackerDbContext(options);
            _dbContext.Database.EnsureCreated();
            //_dbContext.Database.Migrate();

        }

        public void EnsureDeleted()
        {
            _dbContext.Database.EnsureDeleted();

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
