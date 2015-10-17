using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Repository.Interfaces
{
    public interface IFlightRepository
    {
        Flight SelectById(int id);

        /// <summary>
        /// Returns the cheapest flights for specific date, departure/destination city.
        /// Indirect flights are not allowed.
        /// </summary>
        /// <param name="departureCityIATA">Departure city IATA code.</param>
        /// <param name="destinationCityIATA">Destination city IATA code.</param>
        /// <param name="dateTime">Flight date. For example 2015-09-01.</param>
        /// <param name="flightsCount">Maximum best flights.</param>
        /// <returns></returns>
        IEnumerable<Flight> GetTheCheapestByDate(
            string departureCityIATA, string destinationCityIATA,
            DateTime dateTime, int passengerCount, int flightsCount);

        /// <summary>
        /// Returns the cheapest flights for specific date, departure/destination city
        /// Indirect flights are allowed.
        /// </summary>
        /// <param name="departureCityIATA">Departure city IATA code.</param>
        /// <param name="destinationCityIATA">Destination city IATA code.</param>
        /// <param name="dateTime">Flight date. For example 2015-09-01.</param>
        /// <returns></returns>
        IEnumerable<InDirectFlight> GetInDirectTheCheapestByDate(
            string departureCityIATA, string destinationCityIATA,
            DateTime dateTime, int passengerCount);

    }
}
