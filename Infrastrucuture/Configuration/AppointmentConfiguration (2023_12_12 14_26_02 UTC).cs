using Domainlayer.WorkerSchedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    public class AppointmentConfiguration:IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder) 
        {
            builder.HasKey(a => a.Id);
            builder.Property(a=>a.Id).IsRequired().HasConversion(a=>a.value,v=>AppointmentId.FromId(v));
            builder.HasOne<WorkerSchedule>().WithMany().HasForeignKey(a => a.ScheduleId);
            builder.OwnsOne(a=>a.ScheduleId,a=>a.Property(s=>s.value).IsRequired().HasMaxLength(256).HasColumnName("ScheduleId"));
            builder.OwnsOne(a => a.EventId, a => a.Property(a => a.value).IsRequired().HasMaxLength(256).HasColumnName("EventId"));
            builder.OwnsOne(a => a.Datedetails, a => a.Property(a => a.Date).IsRequired().HasColumnName("EventDate"));

        }
    }
}
