using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class InventoryId : Value<InventoryId>
    {
        public string Id { get; internal set; }

        protected InventoryId() { }

        public InventoryId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(InventoryId productid)
        {
            return productid.value;
        }

        public static implicit operator InventoryId(string id) { return new InventoryId(id); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
