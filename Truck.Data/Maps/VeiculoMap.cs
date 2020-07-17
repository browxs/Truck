using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Truck.Domain.Entities;

namespace Truck.Data.Maps
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable(nameof(Veiculo));
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Modelo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("money");
        }
    }
}
