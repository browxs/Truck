namespace Truck.API.DTOs
{
    public class VeiculoRespostaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
