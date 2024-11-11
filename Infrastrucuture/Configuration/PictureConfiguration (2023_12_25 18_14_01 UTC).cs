using Domainlayer.Product;
using Domainlayer.Share;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    public class PictureConfiguration:IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder) 
        {
            builder.HasKey(p => p.pictureid);
            builder.Property(p=>p.pictureid).IsRequired().HasColumnName("PictureId").HasConversion(p=>p.value,v=>ID.Fromstring(v));
            builder.OwnsOne(p => p.url, p => p.Property(u => u.value).IsRequired().HasColumnName("PictureUrl").HasMaxLength(2048));
            builder.HasOne<Product>().WithMany().HasForeignKey(p => p.productid);
            builder.Property(p=>p.productid).IsRequired().HasMaxLength(256).HasColumnName("PictureProductId").HasConversion(pid=>pid.value,v=>ID.Fromstring(v));

        }
    }
}
