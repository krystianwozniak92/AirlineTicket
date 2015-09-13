using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Helpers
{
    public static class RouteHelper
    {
        public static Models.FlightsDb.Country GetDepartureCountry(Route route)
        {
            return route.DepartureAirport.City.Country;
        }
    }
}