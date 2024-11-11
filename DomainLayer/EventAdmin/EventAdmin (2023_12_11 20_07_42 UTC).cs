using Domainlayer.DomainInfrastructure;
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
    public class EventAdmin : AggregateRoot
    {
        public EventAdminId Id { get; private set; }
        public EventId EventId { get; private set; }
        public DateDetails DateDetail { get; private set; }
        public EventCategoryId EventCategoryId { get; private set; }

        private List<EventWorkers> Workers = new List<EventWorkers>();
        public IReadOnlyCollection<EventWorkers> _Workers => Workers.AsReadOnly();

        private List<EventEquipmentAdmin> Eventequipment = new List<EventEquipmentAdmin>();

        public IReadOnlyCollection<EventEquipmentAdmin> _EventEquipment => Eventequipment.AsReadOnly();


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

        public void AddEventAdminEquipments(List<EventEquipmentAdmin> e) 
        {
            this.Eventequipment.AddRange(e);
        }
        public void AddEventAdminEquipment(EventEquipmentAdmin equipment) 
        {
            var ExistingEvent = this.Eventequipment.Where(e=> e.Id == equipment.Id).FirstOrDefault();
            var SameSubcategory = this.Eventequipment.Where(e=> e.Subcategoryid == equipment.Subcategoryid).FirstOrDefault();
            if (ExistingEvent != null) 
            {
                throw new ArgumentException("The equipment exists");
            }
            if(SameSubcategory != null) 
            {
              this.DeleteEventAdminEquipment(SameSubcategory);
            }
            this.Eventequipment.Add(equipment);
        }

        public void DeleteEventAdminEquipment(EventEquipmentAdmin eq) 
        {
            this.Eventequipment.Remove(eq);
        }
        public void DeleteEventWorker(string EventAdminWorkerid) 
        {
            var EventWorker = Workers.Where(w=>w.EventWorkerId== EventAdminWorkerid).FirstOrDefault();

            if(EventWorker == null) 
            {
                throw new ArgumentNullException("Worker dosen't exist");
            }
            Workers.Remove(EventWorker);
        }

        
    }
}
