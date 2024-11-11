using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrtucture
{
    public class Entity<Tid> where Tid : Value<Tid>
    {
        private readonly List<Domainevent> events;

        public Tid id { get; protected set; }
        public Entity() 
        {
            events = new List<Domainevent>();
        }

        public void RaiseEvent(Domainevent @event) 
        {
            events.Add(@event);
        }

        public void clearevents() 
        {
            events.Clear();
        }
    }
}
