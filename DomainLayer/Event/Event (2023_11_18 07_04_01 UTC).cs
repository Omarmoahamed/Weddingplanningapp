using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public class Event
    {
        public EventId EventId { get; private set; }

        public CustomerId CustomerId { get; private set; }

        public DateDetails DateDetails { get; private set; }


    }
}
