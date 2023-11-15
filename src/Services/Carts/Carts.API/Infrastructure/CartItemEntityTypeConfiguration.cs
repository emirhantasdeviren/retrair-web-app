using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Inveon.eCommerceExample.Carts.API.Models;

namespace Inveon.eCommerceExample.Carts.API.Infrastructure;

internal class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("cart_items");

        builder.HasKey(i => i.Id);
        builder.HasIndex(i => new { i.CartId, i.ProductId }).IsUnique();

        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.ProductId).IsRequired();
        builder.HasOne(i => i.Cart).WithMany(c => c.Items);
    }
}
