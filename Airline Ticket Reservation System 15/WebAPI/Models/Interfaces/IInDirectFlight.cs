using System.Collections.Generic;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Models.Interfaces
{
    public interface IInDirectFlight
    {
        /// <summary>
        /// Flights that make up that in direct flight (connection).
        /// </summary>
        List<Flight> Flights { get; set; }

        /// <summary>
        /// Sum of all flights base prices.
        /// </summary>
        decimal TotalBasePrice { get; set; }

        /// <summary>
        /// Sum of flights and connection times.
        /// </summary>
        int TotalDuration { get; set; }
    }
}
