using System.Collections.Generic;

namespace Truck.API.DTOs
{
    public class CategoriaVeiculosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<VeiculoRespostaDTO> Veiculos { get; set; }
    }
}
