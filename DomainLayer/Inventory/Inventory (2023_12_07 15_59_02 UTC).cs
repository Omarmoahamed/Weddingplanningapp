using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Inventory
{
    public  class Inventory : AggregateRoot
    {
        public InventoryId InventoryId { get; private set; }

        public InventoryName InventoryName { get; private set; }

        public InventoryCost InventoryCost { get; private set; }

        public InventoryQuantity InventoryQuantity { get; private set; }

        public bool IsAvilable = false;
        private Inventory(string name,double cost,int quantity) 
        {
            InventoryId = Guid.NewGuid().ToString();
            this.InventoryCost = cost;
            this.InventoryQuantity = quantity;
        }
        public static Inventory CreateInventory( string inventoryname, double inventorycost, int inventoryquantity) 
        {
            return new Inventory(inventoryname,inventorycost,inventoryquantity);

        }
        public void Avilability() 
        {
            this.ensurevalidate();
            IsAvilable = true;
        }

    }
}
