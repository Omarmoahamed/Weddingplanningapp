using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.EventAdmin
{
    public static class domainevents
    {
        public class EventWorkerAdded :Domainevent
        {
            public string eventid { get; set; }
            public string workerid {  get; set; }

            public DateTime dateTime { get; set; }
        }
    }
}
