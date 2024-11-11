using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class WorkerId: Value<WorkerId>
    {
        protected WorkerId() { }

        public string value { get; internal set; }
        public WorkerId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException("Categoryid cannot be null");
            }
            this.value = value;
        }

        public static implicit operator string(WorkerId categoryid)
        {
            return categoryid.value;
        }

        public static implicit operator WorkerId(string value) { return new WorkerId(value); }

        public static WorkerId FromId(string value) 
        {
            return new WorkerId(value);
        }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
