using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSpecification
{
    public class WorkerSpecification:AggregateRoot<Categoryid>
    {
        public Categoryid specificationId { get; private set; }
        public WorkerSpecificationName Name { get; private set; }

        private WorkerSpecification(string name) 
        {
            specificationId = Guid.NewGuid().ToString();
            Name = name;
        }

        public static WorkerSpecification CreateWorkerSpecification(string name) 
        {
            return new WorkerSpecification(name);
        }
    }
}
