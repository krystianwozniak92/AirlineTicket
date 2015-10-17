using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.QPX.Response.TripOptionModels;

namespace WebAPI.Helpers
{
    public static class FareHelper
    {
        public static Fare CreateFareFrom(WebAPI.Models.FlightsDb.Flight flight)
        {
            var fare = new Fare
            {
                ID = RandomHelper.GetRandomString(),
                Carrier = flight.Aircraft.Carrier.Code,
                Origin = flight.Route.DepartureAirport.City.IATA,
                Destination = flight.Route.DestinationAirport.City.IATA,
                BasisCode = "MGOLD"
            };

            return fare;
        }
    }
}