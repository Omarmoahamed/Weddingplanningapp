using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSpecification
{
    public class WorkerSpecification
    {
        public Categoryid specificationId { get; private set; }
        public WorkerSpecificationName Name { get; private set; }
    }
}
