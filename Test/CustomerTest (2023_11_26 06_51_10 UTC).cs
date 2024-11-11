using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domainlayer.Customer;
using Domainlayer.DomainServices;
namespace Test
{
    public class CustomerTest
    {
        [Fact]
        public void CreateCustomerTest() 
        {
            var customer = Customer.RegisterCustomer(

                Guid.NewGuid().ToString(),
                "omar",
                "omarh965.5@gmail.com",
                "01100944552",
                new CheckCustomerEmail(),
                new Phonecompanycheck());

            Assert.Equal("omar",customer.customerName );
          

        }
    }
}
