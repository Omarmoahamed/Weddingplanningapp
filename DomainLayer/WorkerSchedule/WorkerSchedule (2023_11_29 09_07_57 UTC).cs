using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using Domainlayer.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.WorkerSchedule
{
    public class WorkerSchedule : AggregateRoot<ScheduleId>
    {
        public ScheduleId ScheduleId { get; private set; }
        public ScheduleWorkerName WorkerName { get; private set; }
        public WorkerId WorkerId { get; private set; }

        private List<Appointment> appointments = new List<Appointment>();

        public IReadOnlyCollection<Appointment> Appointments => appointments.AsReadOnly();
        
        public void CreateAppointment(Appointment appointment) 
        {
            var app = appointments.Where(a=> a.Datedetails == appointment.Datedetails).First();
            if (app != null) 
            {
                throw new DomainExceptions.SameDateTime();
            }
            appointments.Add(appointment);



        }

        public void DeleteAppointment(AppointmentId id) 
        {
            var app = appointments.Where(app=> app.Id == id).First();

            if(app == null) 
            {
                throw new ArgumentNullException("There is no Appointment");
            }

            appointments.Remove(app);
        }

    }
}
