using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Inventory
{
    public  class Inventory
    {
        public InventoryId InventoryId { get; private set; }

        public InventoryName InventoryName { get; private set; }

        public InventoryCost InventoryCost { get; private set; }

        public InventoryQuantity InventoryQuantity { get; private set; }

    }
}
