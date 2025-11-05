using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ExpirationDate).IsRequired();
            builder.Property(p => p.Batch).HasMaxLength(150).IsRequired();
            builder.Property(p => p.SupplierName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ProductBrand).HasMaxLength(200).IsRequired();
        }
    }
}
