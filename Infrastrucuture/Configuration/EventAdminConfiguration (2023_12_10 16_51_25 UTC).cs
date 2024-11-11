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
    public class EventAdminConfiguration : IEntityTypeConfiguration<EventAdmin>
    {
        public void Configure(EntityTypeBuilder<EventAdmin> builder) 
        {
            builder.HasKey(ea=>ea.Id);
            builder.Property(ea=>ea.Id).IsRequired().HasColumnName("EventAdminId").HasConversion(ea=>ea.value,v=> EventAdminId.Fromid(v));
            builder.OwnsOne(ea => ea.EventCategoryId, ea => ea.Property(ec => ec.value).IsRequired().HasColumnName("EventCategoryId").HasMaxLength(256));


        }
    }
}
