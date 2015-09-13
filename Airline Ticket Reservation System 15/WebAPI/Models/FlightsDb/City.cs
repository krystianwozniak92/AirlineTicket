using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class City : IEquatable<City>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }

        public bool Equals(City other)
        {
            return IATA == other.IATA;
        }
    }
}
