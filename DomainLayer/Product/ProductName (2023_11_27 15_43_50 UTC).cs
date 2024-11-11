using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Product
{
    public class ProductName : Value<ProductName>
    {
        protected ProductName() { }
        internal ProductName(string name) 
        {
            this.value = name;
        }

        public string value { get; internal set; }

        public static ProductName createproductname(string value) 
        {
            checkvalidty(value);
            return new ProductName(value);
            
        }
        public static void checkvalidty(string value) 
        {
            if (value.Length > 100) 
            {
                throw new ArgumentOutOfRangeException("Name cannot be longer than 100 words",nameof(value));
            }
        }

        public static implicit operator string(ProductName productName) 
        { 
            return productName.value; 
        }
        public static implicit operator ProductName(string value) { return new ProductName(value); }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
