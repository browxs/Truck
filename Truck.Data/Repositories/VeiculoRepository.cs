using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truck.Domain.Entities;
using Truck.Domain.Repositories;

namespace Truck.Data.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(TruckContext context) : base(context)
        { }

        public async Task<IEnumerable<Veiculo>> GetAllWithCategoriaAsync()
        {
            return await Get()
                .Include(v => v.Categoria)
                .ToListAsync();
        }

        public async Task<Veiculo> GetByIdWithCategoriaAsync(int id)
        {
            return await Get()
                .Include(v => v.Categoria)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Veiculo>> GetByMarcaAsync(string marca)
        {
            return await Get()
                .Include(v => v.Categoria)
                .Where(v => v.Marca.ToLower()
                .Contains(marca.ToLower()))
                .OrderBy(v => v.Modelo)
                .ToListAsync();
        }
    }
}
