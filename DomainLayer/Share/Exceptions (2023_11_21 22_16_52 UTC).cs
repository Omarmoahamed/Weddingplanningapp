﻿using System;
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
    }
}
