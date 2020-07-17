using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Domain.Entities;

namespace Truck.Data
{
    public static class TruckContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .HasData(
                    new Veiculo() { Id = 1, Marca = "Toyota", Modelo = "Corolla", Preco = 40000.0M },
                    new Veiculo() { Id = 2, Marca = "Honda", Modelo = "Civic", Preco = 45000.0M },
                    new Veiculo() { Id = 3, Marca = "Nissan", Modelo = "Versa", Preco = 23000.0M },
                    new Veiculo() { Id = 4, Marca = "Hyundai", Modelo = "HR", Preco = 70000.0M }
                );
        }
    }
}
