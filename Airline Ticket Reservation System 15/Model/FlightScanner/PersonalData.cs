using System.ComponentModel.DataAnnotations;
using Model.FlightScanner.Interfaces;

namespace Model.FlightScanner
{
    public class PersonalData : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DocumentNumber { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
