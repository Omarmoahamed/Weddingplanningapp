using Domainlayer.Customer;
using Domainlayer.EventAdmin;
using Domainlayer.EventCategory;
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
    public class EventAdminConfiguration : IEntityTypeConfiguration<EventAdmin>
    {
        public void Configure(EntityTypeBuilder<EventAdmin> builder) 
        {
            builder.HasKey(ea=>ea.Id);
            builder.Property(ea=>ea.Id).IsRequired().HasColumnName("EventAdminId").HasConversion(ea=>ea.value,v=> ID.Fromstring(v));
            builder.Property(ea => ea.EventCategoryId).IsRequired().HasColumnName("EventCategoryId").HasConversion(ea=>ea.value,v=>ID.Fromstring(v)) ;
            builder.HasOne<EventCategory>().WithOne().HasForeignKey<EventAdmin>(e => e.EventCategoryId);
            builder.OwnsOne(e => e.DateDetail, e => e.Property(e => e.Date).IsRequired().HasColumnName("EventDate").HasColumnType("Smalldatetime"));
            builder.Property(ea=>ea.CustomerId).IsRequired().HasColumnName("EventCustomerId").HasConversion(ea=>ea.value, v=> ID.Fromstring(v));
            builder.HasOne<Customer>().WithMany().HasForeignKey(e=> e.CustomerId);


        }
    }
}
