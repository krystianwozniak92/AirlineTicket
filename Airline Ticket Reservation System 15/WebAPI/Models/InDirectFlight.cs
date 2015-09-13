using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Helpers;
using WebAPI.Models.FlightsDb;
using WebAPI.Models.Interfaces;

namespace WebAPI.Models
{
    /// <summary>
    /// Class represents a connection with change plane available.
    /// </summary>
    public class InDirectFlight : IInDirectFlight
    {
        private decimal _totalBasePrice = -1;
        private int _totalDuration = -1;
        public List<Flight> Flights { get; set; }
        public decimal TotalBasePrice
        {
            get
            {
                if (_totalBasePrice == -1)
                    _totalBasePrice = Flights.Sum(flight => flight.BasePrice);
                return _totalBasePrice;
            }
            set { _totalBasePrice = value; }
        }

        public int TotalDuration
        {
            get
            {
                if (_totalDuration == -1)
                {
                    _totalDuration = 0;
                    for (int i = 0; i < Flights.Count; i++)
                    {
                        // If it's not last flight
                        if (i < Flights.Count - 1)
                        {
                            // Calculate change plane time.
                            var transferTime = (int)FlightHelper.GetChangeTransferTimeSpan(
                                Flights[0], Flights[1]).TotalMinutes;

                            // Add change plane time.
                            _totalDuration += transferTime;
                        }
                        
                        // Add flight time.
                        _totalDuration += Flights.ElementAt(i).Route.Duration;
                    }
                }
                return _totalDuration;
            }
            set { _totalDuration = value; }
        }

        public InDirectFlight(){ }

        public InDirectFlight(Flight flight)
        {
            Flights = new List<Flight> {flight};
        }

        public InDirectFlight(List<Flight> flights)
        {
            Flights = flights;
        }

        public override string ToString()
        {
            decimal totalPrice = 0;
            StringBuilder builder = new StringBuilder();
            foreach (var flight in Flights)
            {
                builder.Append(
                    string.Format("Departure: [{0}] -> Destination: [{1}]\n" +
                                  "Date: [{2}][{3}], Duration: [{4}],\tPrice: [{5}]\n",
                        flight.Route.DepartureAirport.Name,
                        flight.Route.DestinationAirport.Name,
                        flight.Date.ToLongDateString(),
                        flight.Date.ToLongTimeString(),
                        flight.Route.Duration,
                        flight.BasePrice));

                totalPrice += flight.BasePrice;
            }
            builder.Append(string.Format("Total price: [{0} EUR]", totalPrice));
            return builder.ToString();
        }
    }
}
