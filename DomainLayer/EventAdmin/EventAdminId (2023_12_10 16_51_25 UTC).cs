using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventAdminId : Value<EventAdminId>
    {
        public EventAdminId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(EventAdminId EAdminId)
        {
            return EAdminId.value;
        }

        public static implicit operator EventAdminId(string id) { return new EventAdminId(id); }

        public static EventAdminId Fromid(string value) 
        {
            return new EventAdminId(value);
        }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
