using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAPI.Models.FlightsDb;

namespace WebAPI.DAL
{
    public class FlightsContext : DbContext
    {
        public FlightsContext()
            : base()
        {

        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteTax> RouteTaxes { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<ChargeType> ChargeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Relationship between Departure Terminal - Route
            modelBuilder.Entity<Route>()
                .HasRequired(c => c.DepartureAirport)
                .WithMany(d => d.DepartureRoutes)
                .HasForeignKey(e => e.DepartureAirportID);

            // Relationship between Destination Terminal - Route
            modelBuilder.Entity<Route>()
                .HasRequired(c => c.DestinationAirport)
                .WithMany(d => d.DestinationRoutes)
                .HasForeignKey(e => e.DestinationAirportID);

            modelBuilder.Entity<Route>()
                .HasRequired(c => c.DepartureAirport)
                .WithMany(d => d.DepartureRoutes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasRequired(d => d.Country)
                .WithMany(p => p.Cities)
                .WillCascadeOnDelete(false);
        }
    }
}