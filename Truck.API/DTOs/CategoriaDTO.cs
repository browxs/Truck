using System.ComponentModel.DataAnnotations;

namespace Truck.API.DTOs
{
    public class CategoriaDTO
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "limite de caracteres excedido")]
        public string Nome { get; set; }
    }
}
