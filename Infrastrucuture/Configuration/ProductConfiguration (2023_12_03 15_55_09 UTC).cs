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
            builder.Property(p=>p.Productid).IsRequired().HasColumnName("Productid").HasConversion(p=>p.value,v=>Productid.FromId(v));
            builder.HasOne<Category>().WithOne().HasForeignKey<Product>(p => p.Categoryid);
            builder.OwnsOne(p => p.Categoryid, p => p.Property(p => p.value).IsRequired().HasMaxLength(256));


        }
    }
}
