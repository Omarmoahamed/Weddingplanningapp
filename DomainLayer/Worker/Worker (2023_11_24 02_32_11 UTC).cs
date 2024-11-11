using Domainlayer.Share;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Worker
{
    public class Worker : AggregateRoot<WorkerId>
    {
        public WorkerId WorkerId { get;private set; }

        public WorkerName WorkerName { get;private set; }

        public Categoryid SpecificationId { get;private set; }

        private Worker(string name, string specifiationid) 
        {
            this.WorkerId = Guid.NewGuid().ToString();
            this.WorkerName = name;
            this.SpecificationId = specifiationid;
        }

        public static Worker CreateWorker(string name, string specificationid) 
        {
            return new Worker(name, specificationid);
        }

    }
}
