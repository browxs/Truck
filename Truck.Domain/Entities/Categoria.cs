using System.Collections.Generic;

namespace Truck.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
