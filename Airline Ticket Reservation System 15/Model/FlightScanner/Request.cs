using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class Request : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
