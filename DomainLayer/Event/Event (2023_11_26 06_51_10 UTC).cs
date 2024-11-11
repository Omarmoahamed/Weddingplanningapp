using Domainlayer.Share;
using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public class Event:AggregateRoot<EventId>
    {
        public EventId EventId { get; private set; }

        public CustomerId CustomerId { get; private set; }

        public DateDetails DateDetails { get; private set; }

        private readonly List<EventEquipment> EventEquipments = new List<EventEquipment>();

        public IReadOnlyCollection<EventEquipment> _eventEquipment => EventEquipments.AsReadOnly();

        public eventtype EventType { get; private set; }

        public EventCategoryId CategoryId { get; private set; }

        public bool Register = false;

        public static Event createEvent(int type, string customerid, DateTime date) 
        {
            return new Event() {
                EventId = Guid.NewGuid().ToString(), 
                CustomerId = customerid,
                DateDetails = DateDetails.CreateDate(date),
                EventType =(eventtype) Enum.ToObject(typeof(eventtype), type)
            };
        }
        public void AddEquipment (EventEquipment eq) 
        {
            var equipment = EventEquipments.Where(e => e.Subcategoryid == eq.Subcategoryid).First();
            if ( equipment != null) 
            {
                this.DeleteEquipment (equipment);
            }
            
            EventEquipments.Add (eq);

            
            
        }
        public void RequestToRegister() 
        {
            this.ensurevalidate();
            this.Register = true;
            this.RaiseEvent(new domainevents.EventIsRegisterd()
            {
                date = this.DateDetails,
                eventcategoryid = this.CategoryId,
                eventid = this.EventId
            }) ;

        }

        public  void DeleteEquipment(EventEquipment eq) 
        {
            EventEquipments.Remove(eq);
        }

        public enum eventtype 
        {
            closed =0,
            open =1
             
        }

        

    }
}
