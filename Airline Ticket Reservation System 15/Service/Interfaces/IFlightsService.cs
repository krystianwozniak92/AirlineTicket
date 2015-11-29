using System.Threading.Tasks;
using Model.ViewModels;

namespace Service.Interfaces
{
    public interface IFlightsService
    {
        Task<TripOptionViewModels> GetFlights(SearchFlightRequest request);
    }
}
