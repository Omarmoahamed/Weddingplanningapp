using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSchedule
{
    public class Appointment : Entity<AppointmentId>
    {
        public AppointmentId Id { get; private set; }
        public ScheduleId ScheduleId { get; private set; }

        public EventId EventId { get; private set; }

        public DateDetails Datedetails { get; private set; }

        public Appointment(AppointmentId id, string scheduleid,string eventid,DateTime dateDetails) 
        {
            this.Id = id;
            this.ScheduleId = scheduleid;
            this.EventId = eventid;
            this.Datedetails = DateDetails.CreateDate(dateDetails);
        }

        public void UpdateAppointment( string eventid, DateTime date) 
        {
            this.EventId = eventid;
            this.Datedetails = DateDetails.CreateDate(date);
        }
    }
}
