using System;

namespace Model.ViewModels
{
    public class FlightViewModel
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
