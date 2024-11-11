using Domainlayer.Event;
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
            builder.Property(e=>e.EventId).ValueGeneratedNever().HasConversion(e=>e.value,value=> EventId.FromId(value));
            builder.OwnsOne(e=>e.DateDetails,e=>e.Property(e=>e.Date).HasColumnName("EventDate"));
        }
    }
}
