using Domainlayer.Customer;
using Domainlayer.EventAdmin;
using Domainlayer.EventCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    public class EventAdminConfiguration : IEntityTypeConfiguration<EventAdmin>
    {
        public void Configure(EntityTypeBuilder<EventAdmin> builder) 
        {
            builder.HasKey(ea=>ea.Id);
            builder.Property(ea=>ea.Id).IsRequired().HasColumnName("EventAdminId").HasConversion(ea=>ea.value,v=> EventAdminId.Fromid(v));
            builder.OwnsOne(ea => ea.EventCategoryId, ea => ea.Property(ec => ec.value).IsRequired().HasColumnName("EventCategoryId").HasMaxLength(256));
            builder.HasOne<EventCategory>().WithOne().HasForeignKey<EventAdmin>(e => e.EventCategoryId);
            builder.OwnsOne(e => e.DateDetail, e => e.Property(e => e.Date).IsRequired().HasColumnName("EventDate").HasColumnType("Smalldatetime"));
            builder.OwnsOne(e => e.CustomerId, e => e.Property(e => e.value).IsRequired().HasColumnName("EventCustomerId").HasMaxLength(256));
            builder.HasOne<Customer>().WithMany().HasForeignKey(e=> e.CustomerId);


        }
    }
}
