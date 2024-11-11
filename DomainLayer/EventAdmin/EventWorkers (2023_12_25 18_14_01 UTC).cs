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
        public ID EventWorkerId { get; internal set; }
        public ID WorkerId { get; internal set; }

        public WorkerName EventWorkerName { get; internal set; }
        
        public ID SpecificationId { get; internal set; }
        public ID EventAdminId { get; internal set; }

        public EventWorkers(string eventWorkerId, string workerId,  string eventAdminId, string eventWorkerName, string specificationId)
        {
            EventWorkerId = eventWorkerId;
            WorkerId = workerId;
            EventAdminId = eventAdminId;
            EventWorkerName = eventWorkerName;
            SpecificationId = specificationId;
        }
    }
}
