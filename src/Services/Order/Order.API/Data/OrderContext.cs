using Microsoft.EntityFrameworkCore;

namespace Inveon.eCommerceExample.Order.API.Data;

public class OrderContext : DbContext
{
    public DbSet<Models.Order> Orders { get; set; }
    protected readonly IConfiguration Configuration;

    public OrderContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(Configuration.GetConnectionString("OrderApiDatabase"))
            .UseSnakeCaseNamingConvention();
    }
}