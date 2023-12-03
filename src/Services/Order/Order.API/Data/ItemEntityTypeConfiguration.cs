using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inveon.eCommerceExample.Order.API.Data;

internal class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Models.Item>
{
    public void Configure(EntityTypeBuilder<Models.Item> builder)
    {
        builder.ToTable("items");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.PaymentId).IsRequired();
        builder.Property(i => i.PaidPrice).IsRequired();

        builder.HasOne(i => i.Order).WithMany(o => o.Items);
    }
}