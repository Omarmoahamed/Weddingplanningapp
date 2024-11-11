using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Customer
{
    public class CustomerName : Value<CustomerName>
    {
        protected CustomerName() { }

        public string value { get; internal set; }

        public CustomerName(string value)
        {
            if(value == default || value.Length == 0) 
            {
                throw new ArgumentNullException("customer name cant be empty");
            }

            if(value.Length > 40) 
            {
                throw new ArgumentOutOfRangeException("exceeded the limit");
            }
            this.value = value;
        }

        public static implicit operator CustomerName(string value) { return new CustomerName(value); }

        public static implicit operator string(CustomerName customerName) { return customerName.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
