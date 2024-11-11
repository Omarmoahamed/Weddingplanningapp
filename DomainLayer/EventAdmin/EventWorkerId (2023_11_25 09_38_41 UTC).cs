using Domainlayer.WorkerSchedule;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventWorkerId : Value<EventWorkerId>
    {
        protected EventWorkerId() { }

        public EventWorkerId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(EventWorkerId EVWid)
        {
            return EVWid.value;
        }

        public static implicit operator EventWorkerId(string id) { return new EventWorkerId(id); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
