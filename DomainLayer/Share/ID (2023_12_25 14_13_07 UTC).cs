using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class ID : Value<ID>
    {
        protected ID() { }

        public ID(string id) 
        {
            if (string.IsNullOrEmpty(id)) 
            {
                throw new ArgumentNullException("There is no ID");
            }

            this.value = id;
        }

        public string value { get; internal set; }

        public static implicit operator ID(string id) {  return new ID(id); }
        public static implicit operator string(ID id) {  return id.value; }

        public static ID Fromstring(string value) 
        {
            return new ID(value);
        }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
