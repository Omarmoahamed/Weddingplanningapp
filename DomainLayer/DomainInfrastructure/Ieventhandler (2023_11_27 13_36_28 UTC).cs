﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.DomainInfrastructure
{
    internal interface Ieventhandler
    {
        void handle(object @event);
    }
}
