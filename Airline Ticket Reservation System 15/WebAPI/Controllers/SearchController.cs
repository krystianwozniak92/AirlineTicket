using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Model.QPX.Request;
using Model.QPX.Response;
using WebAPI.Converters;
using WebAPI.Helpers;
using WebAPI.Models.Interfaces;
using WebAPI.Repository.Interfaces;


namespace WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        private IFlightRepository _flightRepository;

        public SearchController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        
        public Response PostRequest()
        {
            var requestContent = Request.Content;
            var jsonContent = requestContent.ReadAsStringAsync().Result;
            var request = new JsonRequest(jsonContent);
            var response = ProceedRequest(request);
            return response;
        }

        private Response ProceedRequest(JsonRequest request)
        {
            Response response;

            // Each slice has its own flights solutions
            var slices = new List<IEnumerable<IInDirectFlight>>();

            var maxSolutionsCount = request.Request.Solutions;
            foreach (var slice in request.Request.Slice)
            {
                var passengerCount = PassengerHelper.TotalPassengersCount(request);
                var dt = DateTime.Parse(slice.Date);

                var inDirectFlights = _flightRepository.
                    GetInDirectTheCheapestByDate(slice.Origin, slice.Destination,
                        dt, passengerCount)
                    .ToList(); // Avoid multiple enumeration = multiple database query

                slices.Add(inDirectFlights);
            }

            // Get passengers information

            // Single slices

            // Multiple slices
            response = QpxConverter.MultipleSlicesToResponse(slices, request.Request.Passengers, maxSolutionsCount);

            return response;
        }
    }
}
