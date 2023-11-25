using Inveon.eCommerceExample.Products.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inveon.eCommerceExample.Products.API.Infrastructure;

class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Price).IsRequired();

        builder.HasData(new Product
        {
            Name = "Air Jordan 1 Retro High OG \"Washed Black\"",
            Description = null,
            Price = 4799.90,
            ImagePath = "/images/air-jordan-1-retro-high-og-washed-black.png"
        });

        builder.HasData(new Product
        {
            Name = "Air Jordan 1 Retro High OG \"Chicago Lost & Found\"",
            Description = null,
            Price = 5690.90,
            ImagePath = "/images/air-jordan-1-retro-high-og-chicago-lost-and-found.png"
        });

        builder.HasData(new Product
        {
            Name = "Air Jordan 1 Retro High OG \"Gorge Green\"",
            Description = null,
            Price = 3690.90,
            ImagePath = "/images/air-jordan-1-retro-high-og-gorge-green.png"
        });

        builder.HasData(new Product
        {
            Name = "Air Jordan 1 Retro High OG \"Lucky Green\"",
            Description = null,
            Price = 2890.90,
            ImagePath = "/images/air-jordan-1-retro-high-og-lucky-green.png"
        });

        builder.HasData(new Product
        {
            Name = "Travis Scott x Air Jordan 1 Retro High OG \"Mocha\"",
            Description = null,
            Price = 31790.90,
            ImagePath = "/images/travis-scott-x-air-jordan-1-retro-high-og-mocha.png"
        });
    }
}
