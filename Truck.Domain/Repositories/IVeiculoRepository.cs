using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Domain.Entities;

namespace Truck.Domain.Repositories
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> GetByModelo(string modelo);

        Task<IEnumerable<Veiculo>> GetAllWithCategoriaAsync();

        Task<Veiculo> GetByIdWithCategoriaAsync(int id);
    }
}
