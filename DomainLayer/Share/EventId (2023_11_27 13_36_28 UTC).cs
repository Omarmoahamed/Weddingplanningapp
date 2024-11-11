using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class EventId:Value<EventId>
    {
        protected EventId() { }
        public string value { get; internal set; }

        public EventId(string id) 
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("Eventid cannot be null");
            value = id; 
        }

        public static implicit operator EventId(string id) {  return new EventId(id); }
        public static implicit operator string(EventId id) {  return id.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
