namespace Truck.API.DTOs
{
    public class VeiculoCategoriaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}
