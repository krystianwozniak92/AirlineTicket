using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Route : IComparer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RouteID { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }

        public int DepartureAirportID { get; set; }
        public int DestinationAirportID { get; set; }
        [ForeignKey("DepartureAirportID")]
        public virtual Airport DepartureAirport { get; set; }
        [ForeignKey("DestinationAirportID")]
        public virtual Airport DestinationAirport { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<RouteTax> RouteTaxes { get; set; }


        public int Compare(object x, object y)
        {
            Route a = (Route)x;
            Route b = (Route)y;

            if (a.DepartureAirport == b.DepartureAirport &&
                a.DestinationAirport == b.DestinationAirport)
                return 0;

            if (a.DepartureAirport.Name != b.DepartureAirport.Name)
                return String.CompareOrdinal(a.DepartureAirport.Name, b.DepartureAirport.Name);
            
            return String.CompareOrdinal(a.DestinationAirport.Name, b.DestinationAirport.Name);
        }
    }
}
