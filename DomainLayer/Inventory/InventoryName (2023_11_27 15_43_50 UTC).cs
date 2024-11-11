using Domainlayer.DomainInfrastructure;
using Domainlayer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Inventory
{
    public  class InventoryName: Value<InventoryName>
    {
        protected InventoryName() { }
        internal InventoryName(string name)
        {
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Name cannot be longer than 100 words", nameof(value));
            }
            this.value = name;
        }

        public string value { get; internal set; }

       
        public static implicit operator string(InventoryName InventoryName)
        {
            return InventoryName.value;
        }
        public static implicit operator InventoryName(string value) { return new InventoryName(value); }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
