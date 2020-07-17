using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Truck.Data
{
    public class TruckContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TruckContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.VeiculoMap());

            modelBuilder.Seed();
        }
    }
}
