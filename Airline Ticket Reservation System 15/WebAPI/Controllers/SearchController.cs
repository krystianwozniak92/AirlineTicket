using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Converters;
using WebAPI.Helpers;
using WebAPI.Models.Interfaces;
using WebAPI.Models.QPX.Request;
using WebAPI.Models.QPX.Response;
using WebAPI.Repository;
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
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            JsonRequest request = new JsonRequest(jsonContent);
            Response response = ProceedRequest(request);

            return response;
        }

        private Response ProceedRequest(JsonRequest request)
        {
            Response response = new Response();

            // Each slice has its own flights solutions
            List<IEnumerable<IInDirectFlight>> slices = new List<IEnumerable<IInDirectFlight>>();

            int sliceNumber = 1;

            foreach (var slice in request.Request.Slice)
            {
                int solutionsCount = request.Request.Solutions;
                int passengerCount = PassengerHelper.TotalPassengersCount(request);
                DateTime dt = DateTime.Parse(slice.Date);

                var inDirectFlights = _flightRepository.
                    GetInDirectTheCheapestByDate(slice.Origin, slice.Destination,
                        dt, passengerCount, solutionsCount)
                    .ToList(); // Avoid multiple enumeration = multiple database query

                slices.Add(inDirectFlights);

                /**
                int solutionNumber = 1;
                // DEBUG
                foreach (var inDirectFlight in inDirectFlights)
                    Console.WriteLine("\n#########Slice: [{0}]#########\n--- Solution: [{1}] ---\n{2}\n",
                        sliceNumber, solutionNumber++, inDirectFlight);
                */

                sliceNumber++;
            }

            // Get passengers information

            // Single slices

            // Multiple slices
            response = QPXConverter.MultipleSlicesToResponse(slices, request.Request.Passengers);

            return response;
        }
    }
}
