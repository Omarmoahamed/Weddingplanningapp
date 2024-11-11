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
        public ID AppointmentId { get; private set; }
        public ID ScheduleId { get; private set; }

        public ID EventId { get; private set; }

        public DateDetails Datedetails { get; private set; }

        public Appointment(ID id,string eventid,DateTime dateDetails) 
        {
            this.AppointmentId = id;
            
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
