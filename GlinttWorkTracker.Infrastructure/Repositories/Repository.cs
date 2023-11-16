using GlinttWorkTracker.Domain;
using GlinttWorkTracker.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        protected readonly GlinttWorkTrackerDbContext _dbContext;


        public Repository(GlinttWorkTrackerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public T Create(T e)
        {
            T entity = _dbContext.Set<T>().Add(e).Entity;
            return entity;
        }

        public T Update(T e)
        {
            _dbContext.Entry(e).State = EntityState.Modified;
            T entity = _dbContext.Set<T>().Update(e).Entity;
            return entity;
        }

        public T Delete(T e)
        {
            T entity = _dbContext.Set<T>().Remove(e).Entity;
            return entity;
        }
        public abstract Task<T> UpsertAsync(T e);
        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

    }
}
