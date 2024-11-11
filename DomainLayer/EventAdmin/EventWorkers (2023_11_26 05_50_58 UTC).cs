using Domainlayer.Share;
using Domainlayer.Worker;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
     public class EventWorkers:Entity<EventWorkerId>
    {
        public EventWorkerId EventWorkerId { get; internal set; }
        public WorkerId WorkerId { get; internal set; }

        

        public EventAdminId EventAdminId { get; internal set; }

        public EventWorkers(EventWorkerId eventWorkerId, WorkerId workerId,  EventAdminId eventAdminId)
        {
            EventWorkerId = eventWorkerId;
            WorkerId = workerId;
            EventAdminId = eventAdminId;
        }
    }
}
