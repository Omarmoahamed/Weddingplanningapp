using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Event
{
    public static class domainevents
    {
        public class EventIsRegisterd:Domainevent
        {
            public string eventid { get; set; }

            public string eventcategoryid { get; set; }

            public DateTime date { get; set; }
        }
    }
}
