using Domainlayer.Event;
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
    internal class EventConfiguration:IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder) 
        {
            builder.HasKey(e => e.EventId);
            builder.Property(e=>e.EventId).ValueGeneratedNever().HasConversion(e=>e.value,value=> ID.Fromstring(value)).IsRequired();
            builder.OwnsOne(e=>e.DateDetails,e=>e.Property(e=>e.Date).HasColumnName("EventDate").IsRequired());
            builder.Property(e => e.EventType).ValueGeneratedNever().HasConversion<int>();
            builder.OwnsOne(e => e.CustomerId).Property(e => e.value).HasColumnName("CustomerId").HasMaxLength(256).IsRequired();
            builder.Property(e=>e.CategoryId).IsRequired().HasColumnName("EventCategoryId").HasMaxLength(256).HasConversion(e=>e.value,v=>ID.Fromstring(v));
            builder.HasOne<EventCategory>().WithOne().HasForeignKey<Event>(e => e.CategoryId);
            var navigation = builder.Metadata.FindNavigation(nameof(Event._eventEquipment));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(e=>e.Register).HasDefaultValue(false);
            
           
        }
    }
}
