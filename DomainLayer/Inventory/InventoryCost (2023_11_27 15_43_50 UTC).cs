using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Inventory
{
    public class InventoryCost : Value<InventoryCost>
    {
        protected InventoryCost() 
        {

        }
        public InventoryCost(double value) 
        {
            if(double.IsNegative(value) ) 
            {
                throw new DomainExceptions.CostIsBelow();

            }

            this.value = value;
        }
        public double value { get;internal set; }

        public static implicit operator double(InventoryCost inventoryCost) { return inventoryCost.value; }
        public static implicit operator InventoryCost(double value) { return new InventoryCost(value); }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
