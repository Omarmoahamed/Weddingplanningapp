using Domainlayer.Product;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.DomainServices
{
    public class ProductAttributeService : IfindProductAttribute
    {
        private static readonly Dictionary<string, ProductAttributes> Attributes = new Dictionary<string, ProductAttributes>() 
        {
            {"length", new ProductAttributes("lenght", "M") },
            {"light", new ProductAttributes("ligth", "K") },
            {"None", new ProductAttributes("None","") }
        };

        public ProductAttributes findAttribute(string Attributename, string attributevalue) 
        {
            if (Attributename == "length" || Attributename == "light" || Attributename == "None")
            {
                var value = Attributes.GetValueOrDefault(Attributename)!;
                value.AttributeValue = attributevalue + value.AttributeValue;
                return value;
            }

            return new ProductAttributes(Attributename, attributevalue);

        }
    }
}
