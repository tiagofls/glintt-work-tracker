using GlinttWorkTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<bool> AddWork(T entity);
    }

}
