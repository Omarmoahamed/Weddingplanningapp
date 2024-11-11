using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class EventCategoryId : Value<EventCategoryId>
    {
        protected EventCategoryId() { }

        public string value { get; internal set; }

        public EventCategoryId(string value) 
        {
            if (string.IsNullOrEmpty(value)) 
            {
                throw new ArgumentNullException("Event categoryid is empty");
            }
            this.value = value;
        }

        public static implicit operator EventCategoryId(string value) {  return new EventCategoryId(value); }
        public static implicit operator string(EventCategoryId eventCategoryId) {  return eventCategoryId.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
