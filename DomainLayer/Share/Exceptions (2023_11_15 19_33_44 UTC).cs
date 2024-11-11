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
    }
}
