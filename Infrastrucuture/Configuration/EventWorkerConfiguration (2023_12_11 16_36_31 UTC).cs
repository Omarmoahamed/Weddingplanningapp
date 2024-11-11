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
    public class EventWorkerConfiguration : IEntityTypeConfiguration<EventWorkers>
    {
        public void Configure(EntityTypeBuilder<EventWorkers> builder) 
        {
            builder.HasKey(e => e.EventWorkerId);
            builder.Property(e=>e.EventWorkerId).IsRequired().HasMaxLength(256).HasColumnName("EventWorkerId").HasConversion(e=>e.value,v=> EventWorkerId.FromId(v));
            builder.HasOne<EventAdmin>().WithMany().HasForeignKey(e=>e.EventAdminId);
            builder.OwnsOne(e => e.EventAdminId, e => e.Property(v => v.value).IsRequired().HasMaxLength(256).HasColumnName("EventAdminId"));
            builder.OwnsOne(e => e.EventWorkerName, e => e.Property(e => e.value).IsRequired().HasMaxLength(100).HasColumnName("EventWorkerName"));
            builder.OwnsOne(e => e.WorkerId, e => e.Property(e => e.value).IsRequired().HasMaxLength(256).HasColumnName("EventWorkerId"));
            



        }
    }
}
