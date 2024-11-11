using Domainlayer.DomainInfrastructure;
using Domainlayer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Worker
{
    public class WorkerName: Value<WorkerName>
    {
        protected WorkerName() { }
        internal WorkerName(string name)
        {
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Name cannot be longer than 100 words", nameof(value));
            }
            this.value = name;
        }

        public string value { get; internal set; }

        public static implicit operator WorkerName(string value) { return new WorkerName(value); }
        public static implicit operator string(WorkerName workerName) { return workerName.value; }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
