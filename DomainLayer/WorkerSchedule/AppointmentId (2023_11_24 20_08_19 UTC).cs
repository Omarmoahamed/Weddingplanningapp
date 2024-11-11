using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSchedule
{
    public class AppointmentId: Value<AppointmentId>
    {
        protected AppointmentId() { }

        public AppointmentId(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }
        public string value { get; internal set; }

        public static implicit operator string(AppointmentId appid)
        {
            return appid.value;
        }

        public static implicit operator AppointmentId(string id) { return new AppointmentId(id); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
