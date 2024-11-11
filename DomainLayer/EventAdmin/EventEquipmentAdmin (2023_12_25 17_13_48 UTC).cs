using Domainlayer.Category;
using Domainlayer.Event;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventEquipmentAdmin
    {
        public ID Id { get; set; }
        public EventEquipmentName Name { get; set; }

        public ID Categoryid { get; set; }
        public ID EventAdminId { get; set; }
        public ID Subcategoryid { get; set; }
        public EventEquipmentCost Cost { get; set; }

        public EventEquipmentAdmin(string id, string name , double cost,string EventAdminid) 
        {
            Id = id;
            Name = name;
            Cost = cost;
            this.EventAdminId = EventAdminid;
        }
        
    }
}
