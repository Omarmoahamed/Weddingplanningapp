using Domainlayer.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repositories
{
    internal interface IEventRepository
    {
        Event FindbyId(string id);

        Event FindbyCustomerId(string customerId);
    }
}
