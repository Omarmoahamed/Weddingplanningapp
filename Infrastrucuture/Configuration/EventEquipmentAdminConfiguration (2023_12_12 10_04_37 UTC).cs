using Domainlayer.Event;
using Domainlayer.EventAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    public class EventEquipmentAdminConfiguration : IEntityTypeConfiguration<EventEquipmentAdmin>
    {
        public void Configure(EntityTypeBuilder<EventEquipmentAdmin> builder) 
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).IsRequired().HasColumnName("EventEquipmentId").HasMaxLength(256).HasConversion(e=>e.value,e=>EventEquipmentId.FromId(e));
            builder.OwnsOne(e => e.Name, e => e.Property(e => e.value).IsRequired().HasColumnName("EventEquipmentAdminName").HasMaxLength(100));
            builder.OwnsOne(e => e.Cost, e => e.Property(c => c.value).IsRequired().HasColumnName("EventEquipmentCost"));
            builder.OwnsOne(e => e.Categoryid, e => e.Property(c => c.value).IsRequired().HasColumnName("EventEquipmentCategory").HasMaxLength(256));
            builder.HasOne<EventAdmin>().WithMany().HasForeignKey(e => e.EventAdminId);
            builder.OwnsOne(e => e.EventAdminId, e => e.Property(ea => ea.value).IsRequired().HasColumnName("EventAdminId").HasMaxLength(256));
        }

    }
}
