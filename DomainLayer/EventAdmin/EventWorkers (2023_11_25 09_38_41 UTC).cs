using Domainlayer.Share;
using Domainlayer.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
     public class EventWorkers
    {
        public EventWorkerId EventWorkerId { get; internal set; }
        public WorkerId WorkerId { get; internal set; }

        public WorkerName WorkerName { get; internal set; }

        public EventAdminId EventAdminId { get; internal set; }


    }
}
