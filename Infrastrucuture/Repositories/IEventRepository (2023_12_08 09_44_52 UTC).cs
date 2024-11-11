using Domainlayer.Event;
using Infrastrucuture.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repositories
{
    public interface IEventRepository : IRepoistory
    {
        Task<Event> FindbyId(string id);

        Task<Event> FindbyCustomerId(string customerId);

        void update(Event _event);

        void delete(Event _event);

        
    }
}
