using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventCategory
{
    public  class EventCategory : AggregateRoot<EventCategoryId>
    {
        public EventCategoryId Id { get; private set; }

        public EventCategoryName EventCategoryName { get; private set; }

        private EventCategory(Guid id, string name)
        {
            Id = id.ToString();
            EventCategoryName = name;
        }

        public EventCategory createEventCategory(Guid id , string name) 
        {
            ensurevalidate();

            return new EventCategory(id, name);
        }
    }
}
