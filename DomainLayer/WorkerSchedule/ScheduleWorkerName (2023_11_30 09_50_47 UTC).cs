using Domainlayer.DomainInfrastructure;
using Domainlayer.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSchedule
{
    public class ScheduleWorkerName:Value<ScheduleWorkerName>
    {
        protected ScheduleWorkerName() { }

        internal ScheduleWorkerName(string name)
        {
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Name cannot be longer than 100 words", nameof(value));
            }
            this.value = name;
        }

        public string value { get; internal set; }

        public static implicit operator ScheduleWorkerName(string value) { return new ScheduleWorkerName(value); }
        public static implicit operator string(ScheduleWorkerName workerName) { return workerName.value; }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
