using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inveon.eCommerceExample.Order.API.Data;

internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Models.Order>
{
    public void Configure(EntityTypeBuilder<Models.Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAt).IsRequired();
        builder.Property(o => o.PaymentId).IsRequired();
        builder.Property(o => o.PaidPrice).IsRequired();
        builder.Property(o => o.UserId).IsRequired();
        builder.Property(o => o.BillingAddress).IsRequired();
        builder.Property(o => o.ShippingAddress).IsRequired();
        builder.HasMany(o => o.Items).WithOne(i => i.Order);
    }
}