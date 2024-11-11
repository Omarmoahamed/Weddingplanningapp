using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventEquipmentCost : Value<EventEquipmentCost>
    {
        public double value { get; set; }

        public EventEquipmentCost(double value) 
        {
            if (value < 0) { throw new DomainExceptions.CostIsBelow(); }
            this.value = value;
        }

        public static implicit operator double(EventEquipmentCost eventEquipmentCost) {return eventEquipmentCost.value; }

        public static implicit operator EventEquipmentCost(double value) { return  new EventEquipmentCost(value); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
