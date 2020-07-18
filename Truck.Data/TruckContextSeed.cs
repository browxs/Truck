using Microsoft.EntityFrameworkCore;
using Truck.Domain.Entities;

namespace Truck.Data
{
    public static class TruckContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasData(
                    new Categoria() { Id = 1, Nome = "Caminhão" },
                    new Categoria() { Id = 2, Nome = "Carro" }
                );

            modelBuilder.Entity<Veiculo>()
                .HasData(
                    new Veiculo() { Id = 1, Marca = "Toyota", Modelo = "Corolla", Preco = 40000.0M, CategoriaId = 2 },
                    new Veiculo() { Id = 2, Marca = "Honda", Modelo = "Civic", Preco = 45000.0M, CategoriaId = 2 },
                    new Veiculo() { Id = 3, Marca = "Nissan", Modelo = "Versa", Preco = 23000.0M, CategoriaId = 2 },
                    new Veiculo() { Id = 4, Marca = "Hyundai", Modelo = "HR", Preco = 70000.0M, CategoriaId = 1 }
                );
        }
    }
}
