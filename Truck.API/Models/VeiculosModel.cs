using System.ComponentModel.DataAnnotations;
using Truck.Domain.Entities;

namespace Truck.API.Models
{
    public class VeiculosGet
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }

    public class VeiculoAddEdit
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite de caracteres excedido")]
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "valor inválido")]
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }


    public static class VeiculosModelExtension
    {
        public static VeiculosGet ToVeiculoGet(this Veiculo entity)
        {
            return
                new VeiculosGet
                {
                    Id = entity.Id,
                    Marca = entity.Marca,
                    Modelo = entity.Modelo,
                    Preco = entity.Preco,
                    CategoriaId = entity.CategoriaId,
                    CategoriaNome = entity.Categoria?.Nome
                };
        }

        public static Veiculo ToVeiculo(this VeiculoAddEdit model)
        {
            return new Veiculo
            {
                Marca = model.Marca,
                Modelo = model.Modelo,
                Preco = model.Preco,
                CategoriaId = model.CategoriaId
            };
        }
    }
}
