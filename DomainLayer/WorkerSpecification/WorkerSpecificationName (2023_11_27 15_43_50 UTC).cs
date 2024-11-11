using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSpecification
{
    public class WorkerSpecificationName: Value<WorkerSpecificationName>
    {
        protected WorkerSpecificationName() { }

        public WorkerSpecificationName(string name) 
        {
            if (string.IsNullOrEmpty(name)) 
            {
                throw new ArgumentNullException("Please enter event category name");
            }

            if(name.Length > 128) 
            {
                throw new ArgumentOutOfRangeException("Exceeded the limited number of words");
            }

            this.value = name;
        }
        public string value { get; internal set; }

        public static implicit operator WorkerSpecificationName(string name) {  return new WorkerSpecificationName(name); }

        public static implicit operator string(WorkerSpecificationName name) {  return name.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
