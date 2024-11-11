using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domainlayer.Share.DomainExceptions;

namespace Domainlayer.Share
{
    public class CustomerPhone : Value<CustomerPhone>
    {
        protected CustomerPhone() { }
        private CustomerPhone(string value) 
        {
            this.value = value;
        }

        public string value { get; internal set; }

        public static CustomerPhone CreateCustomerPhone(string phone, Iphonecompanycheck phonecheck) 
        {
            check(phone,phonecheck);
            return new CustomerPhone(phone);
        }

        private static void check(string value, Iphonecompanycheck phonecheck) 
        {
            if (string.IsNullOrEmpty(value)) 
            {
                throw new ArgumentNullException("Your phone is empty");
            }
            if(!(value.Length == 11)) 
            {
              
                       throw new DomainExceptions.CustomerPhoneException();

            }

            if(!phonecheck.Phonecombanynumberscheck( string.Join("",value.Take(3))))
            {
                throw new DomainExceptions.CustomerPhoneException();
            }

            

        }

        public static implicit operator CustomerPhone(string value) { return new CustomerPhone(value); }
        public static implicit operator string(CustomerPhone phone) { return phone.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
