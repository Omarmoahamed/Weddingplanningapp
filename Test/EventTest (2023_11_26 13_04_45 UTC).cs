using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domainlayer.Event;
using Domainlayer.DomainServices;
using Domainlayer.Share;

namespace Test
{
    public class EventTest
    {
        [Fact]
        public void CreateEvent() 
        {
            var ev = Event.createEvent(1,Guid.NewGuid().ToString(),new DateTime(2023,12,27),Guid.NewGuid().ToString());

           var eq = new EventEquipment(Guid.NewGuid().ToString(),"flowers",URL.createurl("https://gghg.com"),ev.EventId,Guid.NewGuid().ToString(),Guid.NewGuid().ToString());

            ev.AddEquipment(eq);

            ev.RequestToRegister();

            Assert.Equal(true, ev.Register);

        }
    }
}
