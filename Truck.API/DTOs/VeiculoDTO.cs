using System.ComponentModel.DataAnnotations;

namespace Truck.API.DTOs
{
    public class VeiculoDTO
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite de caracteres excedido")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(200, ErrorMessage = "limite de caracteres excedido")]
        public string Modelo { get; set; }

        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }
}