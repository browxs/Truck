using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Truck.Domain.Entities;

namespace Truck.Data.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable(nameof(Categoria));
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
