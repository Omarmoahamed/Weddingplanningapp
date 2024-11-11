using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastrtucture;

namespace Domainlayer.Event
{
    public class EventEquipment : Entity<EventEquipmentId>
    {
        public EventEquipmentId Id { get; private set; }

        public EventEquipmentName Name { get; private set; }
        public EventEquipmentPicture picture { get; private set; }

        public EventId EventId { get; private set; }

        public Productid Productid { get; private set; }



    }
}
