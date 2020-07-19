using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Truck.Domain.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByIdAsync(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<bool> CommitAsync();
    }
}
