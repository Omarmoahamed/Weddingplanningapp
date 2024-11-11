﻿using Domainlayer.Event;
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
            builder.Property(eq=>eq.Id).ValueGeneratedNever().HasConversion(eq=>eq.value,value=>EventEquipmentId.FromId(value)).IsRequired().HasColumnName("Id");
            builder.OwnsOne(eq => eq.Name, eq => eq.Property(eq => eq.value).HasMaxLength(100).HasColumnName("EventEquipmentName"));
            builder.OwnsOne(eq => eq.picture, eq => eq.Property(eq => eq.URL).HasColumnName("EventEquipmentPicture"));
            builder.OwnsOne(eq => eq.Productid, eq => eq.Property(eq => eq.value).IsRequired().HasColumnName("EventEquipmentId"));
            builder.OwnsOne(eq => eq.Subcategoryid, eq => eq.Property(eq => eq.value).IsRequired().HasColumnName("EquipmentSubCategoryId"));
            builder.OwnsOne(eq=>eq.EventId,eq=>eq.Property(eq=>eq.value).IsRequired().HasColumnName("EventId").HasMaxLength(256));
            builder.HasOne<Event>().WithMany().HasForeignKey(eq => eq.EventId).IsRequired();

        }
    }
}
