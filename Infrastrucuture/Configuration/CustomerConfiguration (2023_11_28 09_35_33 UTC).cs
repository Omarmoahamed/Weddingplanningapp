using Domainlayer.Customer;
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
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) 
        {
            builder.HasKey(c => c.customerId);
            builder.Property(c=>c.customerId).ValueGeneratedNever().HasConversion(c=>c.value, value=> CustomerId.FromId(value));
            builder.OwnsOne(c => c.customerName, c=>c.Property(c=>c.value).HasColumnName("CustomerName").HasMaxLength(100));
            builder.OwnsOne(c=>c.customerphone, c=>c.Property(c=>c.value).HasColumnName("CustomerPhone").HasMaxLength(14));
            builder.OwnsOne(c => c.customerEmail, c => c.Property(c=>c.value).HasColumnName("CustomerEmail").HasMaxLength(100));

            

        }
    }
}
