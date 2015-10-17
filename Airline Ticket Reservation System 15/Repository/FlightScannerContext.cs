using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model.FlightScanner;

namespace Repository
{
    public class FlightScannerContext : DbContext
    {
        public FlightScannerContext() : base()
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PassengerType> PassengerTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
