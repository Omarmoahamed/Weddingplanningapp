using Domainlayer.Share;
using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Customer
{
    public class Customer:AggregateRoot
    {
        protected Customer() { }
        public CustomerId customerId { get; private set; }

        public CustomerName customerName { get; private set; }
        public CustomerEmail customerEmail { get; private set; }

        public CustomerPhone customerphone { get; private set; }

        private Customer (string id, string name,string email, string phone) 
        {
            this.customerId = id;
            this.customerName = name;
            this.customerEmail = email;
            this.customerphone = phone;
        }

        public static Customer RegisterCustomer(string id, string name, string email, string phone,IcheckCustomerEmail checkemail,Iphonecompanycheck phonecheck) 
        {
            return new Customer
                (
                  id = Guid.NewGuid().ToString(),
                  name = new CustomerName(name),
                  email = CustomerEmail.CreateEmail(email,checkemail),
                  phone = CustomerPhone.CreateCustomerPhone(phone, phonecheck)
                );
        }

       

    }
}
