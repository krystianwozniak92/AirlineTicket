using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class Ticket : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
