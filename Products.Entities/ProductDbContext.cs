using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Products.Entities
{
    public class ProductDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public ProductDbContext(IConfiguration configuration)
        {
            _connectionString = "Server=10.49.78.101;Database=Test1;user id=sa;password=P@ssw0rd;Connection Timeout=30;";//configuration.GetSection("TestConnection")?.Value.ToString();
            _configuration = configuration;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

    }
}
