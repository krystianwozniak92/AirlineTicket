using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DAL;
using WebAPI.Models;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Repository
{
    public class FlightRepository : Interfaces.IFlightRepository
    {
        private FlightsContext _flightsContext;

        public FlightRepository()
        {
            _flightsContext = new FlightsContext();
        }

        public Flight SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetTheCheapestByDate(
            string departureCityIATA, string destinationCityIATA,
            DateTime dateTime, int passengerCount, int flightsCount )
        {
            int departureCityID = GetCityIDByIATA(departureCityIATA);
            int destinationCityID = GetCityIDByIATA(destinationCityIATA);

            var flights = _flightsContext
                .Flights.Where(
                f => f.Date.Year == dateTime.Year &&
                    f.Date.Month == dateTime.Month &&
                    f.Date.Day == dateTime.Day &&
                    f.Route.DepartureAirport.CityID == departureCityID &&
                    f.Route.DestinationAirport.CityID == destinationCityID )
                .OrderBy(f => f.BasePrice)
                .Take(flightsCount);

            return flights.AsEnumerable();
        }

        public IEnumerable<InDirectFlight> GetInDirectTheCheapestByDate(
            string departureCityIATA, string destinationCityIATA,
            DateTime dateTime, int passengerCount )
        {
            int departureCityID = GetCityIDByIATA(departureCityIATA);
            int destinationCityID = GetCityIDByIATA(destinationCityIATA);

            var allFlights = new List<InDirectFlight>();

            // Find direct flights
            var directFlights = _flightsContext
                .Flights.Where(
                    f => f.Date.Year == dateTime.Year &&
                         f.Date.Month == dateTime.Month &&
                         f.Date.Day == dateTime.Day &&
                         f.Route.DepartureAirport.CityID == departureCityID &&
                         f.Route.DestinationAirport.CityID == destinationCityID)
                .OrderBy(f => f.BasePrice);

            foreach (var flight in directFlights.ToList())
                allFlights.Add(new InDirectFlight(flight));

            directFlights = null;

            // For every airport that connect to departure airport find destination airport
            // and check if transfer time is valid/allowed
            const int maxTransferTimeInHours = 8;

            //int solutionCounter = 0;

            // Check if airport has any flight from departure airport
            foreach (var inDirectAirport in _flightsContext.Airports)
            {
                // If it isnt same airport as departure airport
                if (inDirectAirport.CityID != departureCityID)
                {
                    // Take all possible flights from departure to inDirectAirport
                    var departureToInDirectAirport = _flightsContext.Flights.Where(
                        f => f.Date.Year == dateTime.Year &&
                             f.Date.Month == dateTime.Month &&
                             f.Date.Day == dateTime.Day &&
                             f.Route.DepartureAirport.CityID == departureCityID &&
                             f.Route.DestinationAirport.CityID == inDirectAirport.CityID)
                        .OrderBy(f => f.BasePrice);

                    if (departureToInDirectAirport.Any())
                    {
                        foreach (var departureToIndirectFlight in departureToInDirectAirport)
                        {
                            var inDirectToDestination = _flightsContext.Flights.Where(
                                f => f.Date.Year == dateTime.Year &&
                                     f.Date.Month == dateTime.Month &&
                                     f.Date.Day == dateTime.Day &&
                                     (f.Date.Hour - departureToIndirectFlight.Date.Hour < maxTransferTimeInHours) &&
                                     (f.Date.Hour - departureToIndirectFlight.Date.Hour > -maxTransferTimeInHours) &&
                                     f.Date.Hour > departureToIndirectFlight.Date.Hour + 1 + (f.Route.Duration/60) &&
                                     f.Route.DepartureAirport.CityID == inDirectAirport.CityID &&
                                     f.Route.DestinationAirport.CityID == destinationCityID)
                                .OrderBy(f => f.BasePrice);

                            if (inDirectToDestination.Any())
                            {
                                allFlights.Add(new InDirectFlight(new List<Flight>
                                {
                                    departureToIndirectFlight,
                                    inDirectToDestination.FirstOrDefault(),
                                }));
                            }   
                        }
                    }
                }
            }

            return allFlights.OrderBy(InDirectFlight => InDirectFlight.TotalBasePrice);
        }

        private int GetCityIDByIATA(string iata)
        {
            return _flightsContext.Cities.Where(c => c.IATA == iata).FirstOrDefault().CityID;
        }

    }
}
