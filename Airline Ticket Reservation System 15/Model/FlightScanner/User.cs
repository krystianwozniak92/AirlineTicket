using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class User : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
