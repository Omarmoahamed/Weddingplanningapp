using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventCategory
{
    public  class EventCategory : AggregateRoot
    {
        public ID Id { get; private set; }

        public EventCategoryName EventCategoryName { get; private set; }

        private EventCategory(ID id, string name)
        {
            Id = id.ToString()!;
            EventCategoryName = name;
        }

        public EventCategory createEventCategory(ID id , string name) 
        {
            ensurevalidate();

            return new EventCategory(id, name);
        }
    }
}
