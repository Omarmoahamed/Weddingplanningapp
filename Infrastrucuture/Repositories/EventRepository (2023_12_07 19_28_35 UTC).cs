using Domainlayer.Event;
using Infrastrucuture.WeddingDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repositories
{
    internal class EventRepository : IEventRepository
    {
        private WeddingContext context;

        public EventRepository(WeddingContext context) 
        {
            this.context = context;
        }

        public async Task<Event> FindbyId(string id) 
        {
            var _event = await context.events.Include(e => e._eventEquipment).Where(e=>e.EventId == id).SingleAsync();
            return _event;
        }

        public async Task<Event> FindbyCustomerId(string id) 
        {
            var _event = await context.events.Include(e => e._eventEquipment).Where(e=>e.CustomerId == id).SingleAsync();
            return _event;
        }

        public void update(Event entity) 
        {
            context.events.Update(entity);
        }

        public void delete(Event entity) 
        {
            context.Remove(entity);
        }
    }
}
