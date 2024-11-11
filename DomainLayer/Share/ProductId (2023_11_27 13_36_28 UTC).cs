using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domainlayer.DomainInfrastructure;
using Domainlayer.Product;

namespace Domainlayer.Share
{
    public class Productid : Value<Productid>
    {
        
        protected Productid() { }

        public Productid(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(Productid productid) 
        {
            return productid.value;
        }

        public static implicit operator Productid(string id) { return new Productid(id); }

        public override IEnumerable<object> Getmembers()
        {
          yield  return value;
        }


    }
}
