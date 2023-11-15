using Inveon.eCommerceExample.Carts.API.Models;

using Microsoft.EntityFrameworkCore;

namespace Inveon.eCommerceExample.Carts.API.Infrastructure;

public class CartContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    protected readonly IConfiguration Configuration;

    public CartContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemEntityTypeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(Configuration.GetConnectionString("CartApiDatabase"))
            .UseSnakeCaseNamingConvention();
    }
}
