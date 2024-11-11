using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class CustomerId : Value<CustomerId>
    {
       protected CustomerId() { }

        public string value { get; internal set; }


       public CustomerId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException("Categoryid cannot be null");
            }
            this.value = value;
        }

        public static implicit operator string(CustomerId customerId)
        {
            return customerId.value;
        }

        public static CustomerId FromId(string value) 
        {
            return new CustomerId(value);
        }

        public static implicit operator CustomerId(String value) { return new CustomerId(value); }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }


    }
}
