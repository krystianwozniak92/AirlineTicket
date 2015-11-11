using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class Passenger : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int PersonalDataId { get; set; }
        public PersonalData PersonalData { get; set; }
        public int PassengerTypeId { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
