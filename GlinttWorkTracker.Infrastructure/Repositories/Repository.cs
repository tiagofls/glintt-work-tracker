using GlinttWorkTracker.Domain;
using GlinttWorkTracker.Domain.Models;
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
            _dbContext = dbContext;
        }

        public T Create(T e)
        {
            T entity = _dbContext.Set<T>().Add(e).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T e)
        {
            T entity = _dbContext.Set<T>().Update(e).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
        public T Remove(T e)
        {
            T entity = _dbContext.Set<T>().Remove(e).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
        public T GetById(int id)
        {
            T entity = _dbContext.Set<T>().Find(id);
            _dbContext.SaveChanges();
            return entity;
        }

        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task<bool> Add(T entity);
        public abstract Task<bool> Update_(T entity);
        public abstract Task<bool> Delete(T entity);
        public abstract Task<T> FindById(string id);
    }
}
