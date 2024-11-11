using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domainlayer;
using Domainlayer.Customer;
using Domainlayer.Worker;
using Domainlayer.WorkerSpecification;
using Domainlayer.Event;
using Domainlayer.WorkerSchedule;

namespace Infrastrucuture.WeddingDb
{
    public class WeddingContext:DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> dboptions):base(dboptions) 
        {

        }

        public DbSet<Customer> customers => Set<Customer>();
        public DbSet<Worker> workers => Set<Worker>();
        public DbSet<WorkerSpecification> workerSpecs => Set<WorkerSpecification>();

        public DbSet<Event> events => Set<Event>();

        public DbSet<EventEquipment> eventsEquipment => Set<EventEquipment>();
        public DbSet<WorkerSchedule> workerSchedules => Set<WorkerSchedule>();
        public DbSet<Appointment> appointments => Set<Appointment>();




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
