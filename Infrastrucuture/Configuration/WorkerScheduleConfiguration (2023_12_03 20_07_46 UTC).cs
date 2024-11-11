
using Domainlayer.Worker;
using Domainlayer.WorkerSchedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
      public class WorkerScheduleConfiguration:IEntityTypeConfiguration<WorkerSchedule>
    {
        public void Configure(EntityTypeBuilder<WorkerSchedule> builder) 
        {
            builder.HasKey(w=>w.ScheduleId);
            builder.Property(w=>w.ScheduleId).IsRequired().ValueGeneratedNever().HasConversion(w=>w.value,v=> ScheduleId.FromId(v));
            builder.OwnsOne(w => w.WorkerName, w => w.Property(w => w.value).HasColumnName("WorkerName").HasMaxLength(100));
            builder.OwnsOne(w => w.WorkerId, w => w.Property(w => w.value).IsRequired().HasColumnName("WorkerId"));
            var navigation = builder.Metadata.FindNavigation(nameof(WorkerSchedule.Appointments));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        }

    }
}
