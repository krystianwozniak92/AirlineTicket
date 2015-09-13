using System.Linq;
using WebAPI.DAL;
using WebAPI.Models.FlightsDb;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private FlightsContext _flightsContext;

        public TaxRepository()
        {
            _flightsContext = new FlightsContext();
        }

        public Tax GetById(int id)
        {
            return _flightsContext.Taxes.FirstOrDefault(t => t.TaxID == id);
        }
    }
}
