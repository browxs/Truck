using Truck.Domain.Entities;
using Truck.Domain.Repositories;

namespace Truck.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(TruckContext context) : base(context)
        { }
    }
}
