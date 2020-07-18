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
            return await
                        _set
                            .Include(p => p.Categoria)
                        .ToListAsync();
        }

        public async Task<Veiculo> GetByIdWithCategoriaAsync(int id)
        {
            return await
                        _set
                            .Include(p => p.Categoria)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Veiculo>> GetByModelo(string modelo)
        {
            return await _set.Where(p => p.Modelo.Contains(modelo)).ToListAsync();
        }
    }
}
