using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Domain.Repositories;

namespace Truck.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TruckContext _context;
        protected readonly DbSet<T> _set;

        public Repository(TruckContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _set.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _context.SaveChanges();
        }
    }
}
