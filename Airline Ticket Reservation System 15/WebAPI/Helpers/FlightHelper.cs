using System;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Helpers
{
    public static class FlightHelper
    {
        /// <summary>
        /// Returns flight arrival date.
        /// </summary>
        /// <param name="flight">Flight for which to return a arrival date.</param>
        /// <returns></returns>
        public static DateTime GetFlightArrivalDate(Flight flight)
        {
            return flight.Date.AddMinutes(flight.Route.Duration);
        }

        /// <summary>
        /// Timespan between first flight arrival time and second flight departure time.
        /// </summary>
        /// <param name="first">First flight to determine arrival time of first flight.</param>
        /// <param name="second">Second flight to determine departure time of second flight.</param>
        /// <returns></returns>
        public static TimeSpan GetChangeTransferTimeSpan(Flight first, Flight second)
        {
            if(first.Date > second.Date)
                throw new ArgumentException("First flight has later date than second flight!");
            if(ReferenceEquals(first, second))
                throw new ArgumentException("First and second flights are the same objects!");
            return second.Date - GetFlightArrivalDate(first);
        }

        
    }
}
