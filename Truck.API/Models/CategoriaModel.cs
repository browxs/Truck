using System.ComponentModel.DataAnnotations;
using Truck.Domain.Entities;

namespace Truck.API.Models
{
    public class CategoriasGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class CategoriaAddEdit
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite de caracteres excedido")]
        public string Nome { get; set; }
    }

    public static class CategoriasModelExtensions
    {

        public static CategoriasGet ToCategoriaGet(this Categoria data) =>
            new CategoriasGet
            {
                Id = data.Id,
                Nome = data.Nome
            };

        public static Categoria ToCategoria(this CategoriaAddEdit model) =>
            new Categoria
            {
                Nome = model.Nome
            };
    }
}
