using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.TotalAmount).IsRequired();
        builder.Property(s => s.TotalAmountWithDiscount).IsRequired();

        builder.HasIndex(x => x.Number).IsUnique();
        builder.Property(x => x.Number)
               .ValueGeneratedOnAdd()
               .IsRequired();
    }
}
