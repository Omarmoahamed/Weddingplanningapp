using Domainlayer.Category;
using Domainlayer.Product;
using Domainlayer.Share;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.HasKey(p => p.Productid);
            builder.Property(p=>p.Productid).IsRequired().HasColumnName("Productid").HasConversion(p=>p.value,v=>ID.Fromstring(v));
            builder.HasOne<Category>().WithMany().HasForeignKey(p => p.Categoryid);
            builder.Property(p=>p.Categoryid).IsRequired().HasColumnName("ProductCategoryId").HasConversion(c=>c.value,v=>ID.Fromstring(v));
            builder.OwnsOne(p=>p.ProductDescription,p=>p.Property(p=>p.value).IsRequired().HasMaxLength(1000).HasColumnName("ProductDescription"));
            builder.OwnsOne(p => p.ProductName, p => p.Property(p => p.value).IsRequired().HasMaxLength(100).HasColumnName("ProductName"));
            builder.OwnsOne(p => p.ProductAttributes, p => { p.Property(p => p.AttributeValue).IsRequired().HasMaxLength(10).HasColumnName("ProductAttributeValue");
                p.Property(p => p.Attributename).IsRequired().HasMaxLength(14).HasColumnName("ProductAttributeName");
            });
            var navigation = builder.Metadata.FindNavigation(nameof(Product.Pictures));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(p => p.Published).HasDefaultValue(false).HasColumnName("ProductIsPublished");

        }
    }
}
