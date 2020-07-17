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

        public async Task<IEnumerable<Veiculo>> GetByMarca(string marca)
        {
            return await _set.Where(p => p.Marca.Contains(marca)).ToListAsync();
        }
    }
}
