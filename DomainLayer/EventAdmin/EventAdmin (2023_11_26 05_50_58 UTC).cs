using Domainlayer.Event;
using Domainlayer.EventCategory;
using Domainlayer.Share;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public class EventAdmin : AggregateRoot<EventAdminId>
    {
        public EventAdminId Id { get; private set; }
        public EventId EventId { get; private set; }
        public DateDetails DateDetail { get; private set; }
        public EventCategoryId EventCategoryId { get; private set; }

        private List<EventWorkers> Workers = new List<EventWorkers>();
        public IReadOnlyCollection<EventWorkers> _Workers => Workers.AsReadOnly();

        public EventAdmin(string id, string eventid, DateTime date, string eventcategoryid) 
        {
            Id = id;
            EventId = eventid;
            DateDetail = DateDetails.CreateDate(date);
            EventCategoryId = eventcategoryid;
        }

        public void AddEventWorker(EventWorkers worker) 
        {
            var eventworker = Workers.Where(w=> w.WorkerId == worker.WorkerId).FirstOrDefault();

            if(eventworker != null) 
            {
                throw new DomainExceptions.EventWorkerExists();
            }

            Workers.Add(worker);
            this.RaiseEvent(new domainevents.EventWorkerAdded()
            {
                dateTime = this.DateDetail,
                workerid = worker.WorkerId,
                eventid = this.EventId
            }) ;
        }

        public void DeleteEventWorker(string Eventworkerid) 
        {
            var EventWorker = Workers.Where(w=>w.EventWorkerId== Eventworkerid).FirstOrDefault();

            if(EventWorker == null) 
            {
                throw new ArgumentNullException("Worker dosen't exist");
            }
            Workers.Remove(EventWorker);
        }

        
    }
}
