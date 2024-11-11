using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public static class DomainExceptions
    {
        public class CustomerPhoneException : System.Exception
        {
            public CustomerPhoneException():base("Your phone number is invalid") { }

        }

        public class EmailInvalidException : System.Exception 
        {
            public EmailInvalidException():base("Your email is invalid") { }
        }

        public class InvalidEntity : System.Exception 
        {
            public InvalidEntity(object entity): base($"The {entity.GetType().Name} is null") { }
        }

        public class CostIsBelow : System.Exception 
        {
            public CostIsBelow():base("cost is below zero") { }
        }

        public class QuantityIsBelow: Exception 
        {
            public QuantityIsBelow():base("quantity is below zero") { }
        }

        public class SameDateTime : Exception 
        {
            public SameDateTime():base("The worker have appointment at the same time") { }
        }
        public class EventWorkerExists : Exception 
        {
            public EventWorkerExists(): base("The worker already Exists") { }
        }
    }
}
