using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domainlayer.DomainInfrastructure;

namespace Domainlayer.Event
{
    public class EventEquipment : Entity<EventEquipmentId>
    {
        protected EventEquipment() { }
        public ID Id { get; private set; }

        public EventEquipmentName Name { get; private set; }
        public EventEquipmentPicture picture { get; private set; }

        public ID EventId { get; private set; }

        public ID Productid { get; private set; }

        public ID Subcategoryid { get; private set; }

        
        public EventEquipment(string id,string name,URL url ,string eventid, string productid,string subcategoryid) 
        {
            Id = id;
            Name = name;
            picture = url;
           this.EventId = eventid;
            this.Productid = productid;
            this.Subcategoryid = subcategoryid;
        }
    }
}
