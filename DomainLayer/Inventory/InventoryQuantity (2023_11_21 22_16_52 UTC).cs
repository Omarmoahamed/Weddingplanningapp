using Domainlayer.Share;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Inventory
{
    public class InventoryQuantity : Value<InventoryQuantity>
    {
        protected InventoryQuantity() { }

        public InventoryQuantity(int quantity)
        {
            if (quantity < 0) 
            {
                throw new DomainExceptions.QuantityIsBelow();
            }

            this.value = quantity;
        }
        public int value { get;internal set; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value ;
        }

        public static implicit operator int(InventoryQuantity quantity) { return quantity.value ;}

        public static implicit operator InventoryQuantity(int value) { return new InventoryQuantity(value); }


    }
}
