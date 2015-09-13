using System.Linq;
using WebAPI.DAL;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Repository
{
    public class RouteRepository
    {
        private FlightsContext _flightsContext;

        public RouteRepository()
        {
            _flightsContext = new FlightsContext();
        }

        public Route GetRouteById(int id)
        {
            return _flightsContext.Routes.FirstOrDefault(r => r.RouteID == id);
        }
    }
}
