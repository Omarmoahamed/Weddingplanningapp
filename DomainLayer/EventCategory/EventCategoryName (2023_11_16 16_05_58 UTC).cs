using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventCategory
{
    public class EventCategoryName: Value<EventCategoryName>
    {
        protected EventCategoryName() { }

        public EventCategoryName(string name) 
        {
            if (string.IsNullOrEmpty(name)) 
            {
                throw new ArgumentNullException("Please enter event category name");
            }

            if(name.Length > 128) 
            {
                throw new ArgumentOutOfRangeException("Exceeded the limited number of words");
            }

            this.value = name;
        }
        public string value { get; internal set; }

        public static implicit operator EventCategoryName(string name) {  return new EventCategoryName(name); }

        public static implicit operator string(EventCategoryName name) {  return name.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
