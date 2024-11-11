﻿using Domainlayer.Share;
using Domainlayer.Worker;
using Domainlayer.WorkerSpecification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    public class WorkerConfiguration:IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder) 
        {
            builder.HasKey();
            builder.Property(w=>w.WorkerId).IsRequired().ValueGeneratedNever().HasConversion(w=>w.value,value=> WorkerId.FromId(value));
            builder.OwnsOne(w => w.WorkerName, w => w.Property(w => w.value).IsRequired().HasColumnName("WorkerName"));
            builder.OwnsOne(w => w.workerphone, w => w.Property(w => w.value).IsRequired().HasColumnName("WorkerPhone"));
            builder.HasOne<WorkerSpecification>().WithOne().HasForeignKey<Worker>(w => w.SpecificationId).IsRequired();
        }
    }
}