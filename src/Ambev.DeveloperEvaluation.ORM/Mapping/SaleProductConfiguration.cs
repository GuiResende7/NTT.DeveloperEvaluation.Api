using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SaleProducts");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.HasOne(s => s.Product)
               .WithMany(p => p.SaleProducts)
               .HasForeignKey(s => s.ProductId)
               .IsRequired();

        builder.HasOne(s => s.Sale)
               .WithMany(s => s.SaleProducts)
               .HasForeignKey(s => s.SaleId)
               .IsRequired();
    }
}
