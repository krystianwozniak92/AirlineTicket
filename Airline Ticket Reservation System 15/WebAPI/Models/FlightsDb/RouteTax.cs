using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class RouteTax : IEquatable<RouteTax>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RouteTaxID { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }

        public int RouteID { get; set; }
        public int TaxID { get; set; }
        
        // Navigation property
        public virtual Route Route { get; set; }
        public virtual Tax Tax { get; set; }

        public bool Equals(RouteTax other)
        {
            return IdNumber == other.IdNumber;
        }
    }
}
