using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Carrier : IEquatable<Carrier>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarrierID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Aircraft> Aircrafts { get; set; }

        public bool Equals(Carrier other)
        {
            return Code == other.Code;
        }
    }
}
