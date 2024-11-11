using Domainlayer.Product;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public  class EventEquipmentName : Value<EventEquipmentName>
    {
        protected EventEquipmentName() { }
        internal EventEquipmentName(string name)
        {
            this.value = name;
        }

        public string value { get; internal set; }

        public static EventEquipmentName createproductname(string value)
        {
            checkvalidty(value);
            return new EventEquipmentName(value);

        }
        public static void checkvalidty(string value)
        {
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Name cannot be longer than 100 words", nameof(value));
            }
        }

        public static implicit operator string(EventEquipmentName productName)
        {
            return productName.value;
        }
        public static implicit operator EventEquipmentName(string value) { return new EventEquipmentName(value); }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }


    }
}
