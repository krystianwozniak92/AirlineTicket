using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class Country : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string IsoCode { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
