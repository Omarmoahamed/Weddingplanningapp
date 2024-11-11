using Domainlayer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public interface IfindProductAttribute
    {
        ProductAttributes findAttribute(string Attributename,string attributevalue);
    }
}
