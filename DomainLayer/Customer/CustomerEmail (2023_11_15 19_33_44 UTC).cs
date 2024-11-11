using Domainlayer.Share;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Customer
{
    public class CustomerEmail : Value<CustomerEmail>
    {
        protected CustomerEmail() { }

        public string value { get; internal set; }

        private CustomerEmail(string value)
        {
            this.value = value;
        }

        internal static CustomerEmail CreateEmail(string value, IcheckCustomerEmail checkCustomerEmail) 
        {
            CheckEmail(value, checkCustomerEmail); 
            return new CustomerEmail(value);
        }
        
        private static void CheckEmail(string email, IcheckCustomerEmail checkCustomerEmail) 
        {
            checkCustomerEmail.CheckEmail(email);
        }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

        public static implicit operator string(CustomerEmail email) { return email.value; }
        public static implicit operator CustomerEmail(string value) { return new CustomerEmail(value); }

    }
}
