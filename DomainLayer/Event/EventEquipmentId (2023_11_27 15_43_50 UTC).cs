using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public class EventEquipmentId : Value<EventEquipmentId>
    {
        protected EventEquipmentId() { }
        public string value { get; internal set; }

        public EventEquipmentId(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("Eventid cannot be null");
            value = id;
        }

        public static implicit operator EventEquipmentId(string id) { return new EventEquipmentId(id); }
        public static implicit operator string(EventEquipmentId id) { return id.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
