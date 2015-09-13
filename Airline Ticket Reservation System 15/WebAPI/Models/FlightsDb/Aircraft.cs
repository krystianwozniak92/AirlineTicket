using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Aircraft : IEquatable<Aircraft>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AircraftID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int CabinID { get; set; }
        public int CarrierID { get; set; }

        public virtual Cabin Cabin { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

        public bool Equals(Aircraft other)
        {
            return Code == other.Code;
        }
    }
}
