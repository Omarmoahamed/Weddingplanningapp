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
    public class EventEquipmentConfiguration:IEntityTypeConfiguration<EventEquipment>
    {
        public void Configure(EntityTypeBuilder<EventEquipment> builder) 
        {
            builder.HasKey(e => e.Id);
            builder.Property(eq=>eq.EventId).ValueGeneratedNever().HasConversion(eq=>eq.value,value=>EventId.FromId(value)).IsRequired();
            builder.OwnsOne(eq => eq.Name, eq => eq.Property(eq => eq.value).HasMaxLength(100).HasColumnName("EventEquipmentName"));

        }
    }
}
