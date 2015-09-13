using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Airport : IEquatable<Airport>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AirportID { get; set; }
        public string IATA { get; set; }
        public string Name { get; set; }

        public int CityID { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Route> DepartureRoutes { get; set; }
        public virtual ICollection<Route> DestinationRoutes { get; set; } 
        public virtual ICollection<Terminal> Terminals { get; set; }

        public bool Equals(Airport other)
        {
            return IATA == other.IATA;
        }
    }
}
