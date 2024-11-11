using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using Domainlayer.Worker;
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

        public WorkerName EventWorkerName { get; internal set; }
        
        public Categoryid SpecificationId { get; internal set; }
        public EventAdminId EventAdminId { get; internal set; }

        public EventWorkers(EventWorkerId eventWorkerId, WorkerId workerId,  EventAdminId eventAdminId, WorkerName eventWorkerName, Categoryid specificationId)
        {
            EventWorkerId = eventWorkerId;
            WorkerId = workerId;
            EventAdminId = eventAdminId;
            EventWorkerName = eventWorkerName;
            SpecificationId = specificationId;
        }
    }
}
