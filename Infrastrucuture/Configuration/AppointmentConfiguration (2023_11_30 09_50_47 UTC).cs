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

        }
    }
}
