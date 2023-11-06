using Inveon.eCommerceExample.Products.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inveon.eCommerceExample.Products.API.Infrastructure;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected readonly IConfiguration Configuration;

    public ProductContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(Configuration.GetConnectionString("ProductApiDatabase"))
            .UseSnakeCaseNamingConvention();
    }
}
