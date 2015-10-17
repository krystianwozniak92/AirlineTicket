using System.Collections.Generic;
using System.Linq;
using WebAPI.DAL;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Repository
{
    public class RouteTaxRepository
    {
        private FlightsContext _flightsContext;

        public IEnumerable<RouteTax> GetRouteTaxes(Flight flight)
        {
            return flight.Route.RouteTaxes;
        }

        public RouteTaxRepository()
        {
            _flightsContext = new FlightsContext();
        }
    }
}
