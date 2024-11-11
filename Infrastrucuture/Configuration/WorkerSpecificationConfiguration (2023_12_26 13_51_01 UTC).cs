using Domainlayer.Share;
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
    internal class WorkerSpecificationConfiguration : IEntityTypeConfiguration<WorkerSpecification>
    {
        public void Configure(EntityTypeBuilder<WorkerSpecification> builder) 
        {
            builder.HasKey(ws => ws.specificationId);
            builder.Property(ws => ws.specificationId).IsRequired().HasColumnName("WorkerSpecificationId").HasMaxLength(256).HasConversion(id => id.value, v => ID.Fromstring(v));
            builder.OwnsOne(w => w.Name, w => w.Property(n => n.value).IsRequired().HasColumnName("WorkerSpecificationName").HasMaxLength(200));
            
        }
    }
}
