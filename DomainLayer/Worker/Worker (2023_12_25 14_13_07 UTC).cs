using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Worker
{
    public class Worker : AggregateRoot
    {
        public ID WorkerId { get;private set; }

        public WorkerName WorkerName { get;private set; }

        public ID SpecificationId { get;private set; }

        public CustomerPhone workerphone { get; private set; }

        private Worker(string name, string specifiationid, CustomerPhone phone) 
        {
            this.WorkerId = Guid.NewGuid().ToString();
            this.WorkerName = name;
            this.SpecificationId = specifiationid;
            this.workerphone = phone;
        }

        public static Worker CreateWorker(string name, string specificationid,CustomerPhone phone) 
        {
            return new Worker(name, specificationid, phone);
        }

    }
}
