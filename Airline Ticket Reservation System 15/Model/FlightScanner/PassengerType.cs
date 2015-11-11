using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class PassengerType : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
