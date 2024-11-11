using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public class EventEquipmentPicture
    {
        protected EventEquipmentPicture() { }

        public EventEquipmentPicture(string pictureurl) 
        {
            this.URL = pictureurl;

        }
        public URL URL { get;  internal set; }

        public static implicit operator EventEquipmentPicture(URL uRL) { return new EventEquipmentPicture(uRL); }

        public static implicit operator URL(EventEquipmentPicture e) { return e.URL; }

    }
}
