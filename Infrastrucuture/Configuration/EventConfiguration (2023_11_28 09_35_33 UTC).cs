﻿using Domainlayer.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Configuration
{
    internal class EventConfiguration:IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder) 
        {

        }
    }
}
