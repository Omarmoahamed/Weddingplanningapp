using Domainlayer.Event;
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

        public EventEquipmentCost Cost { get; set; }

        public EventEquipmentAdmin(string id, string name , double cost) 
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
        
    }
}
