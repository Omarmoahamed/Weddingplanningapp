using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Domainlayer.Product
{
    public class ProductCost : Value<ProductCost>
    {
        public double Value { get; set; }

        public ProductCost(double value)
        {
            if (value < 0) 
            {
                throw new DomainExceptions.CostIsBelow();
            }
            Value = value;
        }   

        public static implicit operator double(ProductCost productCost) {  return productCost.Value; }

        public static implicit operator ProductCost(double value) { return new ProductCost(value); }

        public override IEnumerable<object> Getmembers()
        {
            yield return Value;
        }
    }
}
