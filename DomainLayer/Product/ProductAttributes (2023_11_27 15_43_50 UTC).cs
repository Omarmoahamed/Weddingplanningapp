using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Product
{
    public class ProductAttributes : Value<ProductAttributes>
    {
        protected ProductAttributes() { }
        public string AttributeValue { get; internal set; }
        public string Attributename { get; internal set; }


       
      public ProductAttributes(string attributeValue, string attributename)
        {
            AttributeValue = attributeValue;
            Attributename = attributename;
        }

        public static ProductAttributes createAttribute(string attributename, string attributevalue, IfindProductAttribute findattribute) 
        {
           checkvalidty(attributename, attributevalue);
           return findattribute.findAttribute(attributename, attributevalue);

        }

        public static void checkvalidty( string Attributename, string Attributevalue) 
        {
            if(Attributename == null) { throw new ArgumentNullException("you must specify attribute name"); }
            if(Attributevalue == null) { throw new ArgumentNullException("you must insert value"); }

        }

        public override IEnumerable<object> Getmembers()
        {
            yield return Attributename; 
            yield return AttributeValue;
        }
    }
}
