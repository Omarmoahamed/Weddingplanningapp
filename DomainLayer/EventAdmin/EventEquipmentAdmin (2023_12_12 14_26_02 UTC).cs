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
        public EventEquipmentId Id { get; set; }
        public EventEquipmentName Name { get; set; }

        public Categoryid Categoryid { get; set; }
        public EventAdminId EventAdminId { get; set; }
        public SubCategoryid Subcategoryid { get; set; }
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
