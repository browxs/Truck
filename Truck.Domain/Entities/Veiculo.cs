namespace Truck.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public void Update(string marca, string modelo, decimal preco, int categoriaId)
        {
            Marca = marca;
            Modelo = modelo;
            Preco = preco;
            CategoriaId = categoriaId;
        }
    }
}
