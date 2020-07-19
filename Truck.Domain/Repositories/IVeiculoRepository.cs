using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Domain.Entities;

namespace Truck.Domain.Repositories
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> GetAllWithCategoriaAsync();
        Task<Veiculo> GetByIdWithCategoriaAsync(int id);
        Task<IEnumerable<Veiculo>> GetByMarcaAsync(string marca);
    }
}
