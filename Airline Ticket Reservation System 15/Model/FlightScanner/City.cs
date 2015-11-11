using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class City : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string IATA { get; set; }
        public bool IsDeleted { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Request> Requests { get; set; } 
    }
}
