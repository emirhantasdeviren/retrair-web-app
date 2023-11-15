using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Inveon.eCommerceExample.Carts.API.Models;

namespace Inveon.eCommerceExample.Carts.API.Infrastructure;

internal class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("carts");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
        builder.HasMany(c => c.Items).WithOne(i => i.Cart);
    }
}
