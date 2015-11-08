using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Model.QPX.Request;
using Model.QPX.Response;
using Service.JsonSerializer;
using WebAPI.Converters;
using WebAPI.Helpers;
using WebAPI.Models.Interfaces;
using WebAPI.Repository.Interfaces;


namespace WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IFlightRepository _flightRepository;

        public SearchController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public HttpResponseMessage PostRequest()
        {
            var requestContent = Request.Content;
            var jsonContent = requestContent.ReadAsStringAsync().Result;
            var request = new JsonRequest(jsonContent);
            var response = ProceedRequest(request);

            var jsonResponse = this.Request.CreateResponse(HttpStatusCode.OK);
            jsonResponse.Content = new StringContent(LowercaseJsonSerializer.SerializeObject(response), Encoding.UTF8, "application/json");
            return jsonResponse;
        }

        private Response ProceedRequest(JsonRequest request)
        {
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
            return QpxConverter.MultipleSlicesToResponse(slices, request.Request.Passengers, maxSolutionsCount);
        }
    }
}
