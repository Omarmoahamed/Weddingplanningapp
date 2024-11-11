using Domainlayer.Event;
using Domainlayer.EventCategory;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventAdmin
    {
        public EventAdminId Id { get; private set; }
        public EventId EventId { get; private set; }
        public DateDetails DateDetail { get; private set; }

        private List<EventWorkers> Workers = new List<EventWorkers>();

        public EventCategoryId EventCategoryId { get; private set; }

        public IReadOnlyCollection<EventWorkers> _Workers => Workers.AsReadOnly();

        public EventAdmin(string id, string eventid, DateTime date, string eventcategoryid) 
        {
            Id = id;
            EventId = eventid;
            DateDetail = DateDetails.CreateDate(date);
            EventCategoryId = eventcategoryid;
        }



        
    }
}
