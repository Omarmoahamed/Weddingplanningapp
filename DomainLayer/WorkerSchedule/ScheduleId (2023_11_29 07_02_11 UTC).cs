using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSchedule
{
    public class ScheduleId: Value<ScheduleId>
    {
        protected ScheduleId() { }

        public ScheduleId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(ScheduleId productid)
        {
            return productid.value;
        }

        public static implicit operator ScheduleId(string id) { return new ScheduleId(id); }

        public static ScheduleId FromId(string value) 
        {
            return new ScheduleId(value);
        }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
