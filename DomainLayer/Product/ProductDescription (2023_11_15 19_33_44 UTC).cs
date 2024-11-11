using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Product
{
     public class ProductDescription : Value<ProductDescription>
    {
        private ProductDescription() { }

        internal ProductDescription(string description) { value = description; }
        public string value {  get; internal set; }

        public static void checkvalidity(string value) 
        {
            if(value.Length > 1000) 
            {
                throw new ArgumentOutOfRangeException("deiscription cannot be more than 1000 words", nameof(value));
            }
        }

        public static ProductDescription createproductdesc(string value) 
        {
          if(value == default) 
            {
                return Nodescription();
            }
            checkvalidity(value);
            return new ProductDescription(value);
        }

        public static implicit operator string(ProductDescription pro) { return pro.value; }

        public static implicit operator ProductDescription(string value) { return new ProductDescription(value); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
        public static ProductDescription Nodescription() { return new ProductDescription(); }
    }
}
