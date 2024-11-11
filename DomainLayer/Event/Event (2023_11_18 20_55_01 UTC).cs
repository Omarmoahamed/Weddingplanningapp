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

        private readonly List<EventEquipment> EventEquipment = new List<EventEquipment>();

        public IReadOnlyCollection<EventEquipment> _eventEquipment => EventEquipment.AsReadOnly();

        public eventtype EventType { get; private set; }
        public enum eventtype 
        {
            closed =0,
            open =1
             
        }

    }
}
