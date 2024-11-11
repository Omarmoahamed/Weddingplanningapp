using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public class EventEquipment
    {
        public EventEquipmentPicture picture { get; private set; }

        public EventId EventId { get; private set; }

        public Productid Productid { get; private set; }



    }
}
