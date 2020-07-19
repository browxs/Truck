using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truck.Domain.Entities;
using Truck.Domain.Repositories;

namespace Truck.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(TruckContext context) : base(context)
        { }

        public async Task<IEnumerable<Categoria>> GetAllWithVeiculosAsync()
        {
            return await Get()
                .Include(c => c.Veiculos)
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }
    }
}
