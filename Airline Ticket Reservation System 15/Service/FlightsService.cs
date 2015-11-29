using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.QPX.Response;
using Model.ViewModels;
using Newtonsoft.Json;
using Service.Interfaces;
using Service.JsonSerializer;

namespace Service
{
    public class FlightsService : IFlightsService
    {
        private async Task<string> SendRequest(SearchFlightRequest request)
        {
            var qpxRequest = Mapper.ToQpxRequest(request);
            return await SendRequest(qpxRequest);
        }

        public async Task<TripOptionViewModels> GetFlights(SearchFlightRequest request)
        {
            string tripOptionsResponse = await SendRequest(request);

            Response response = new Response(tripOptionsResponse);
            TripOptionViewModels tripOptions = new TripOptionViewModels(response);

            return tripOptions;
        }


        private async Task<string> SendRequest(Model.QPX.Request.Request request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1461/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/search/");
                httpRequestMessage.Content = new StringContent(LowercaseJsonSerializer.SerializeObject(new ApiRequest(request)), Encoding.UTF8, "application/json");

                //await client.SendAsync(httpRequestMessage).ContinueWith(responseTask => responseTask.Result.Content.ReadAsStringAsync().Result);
                HttpResponseMessage message = await client.SendAsync(httpRequestMessage);
                return await message.Content.ReadAsStringAsync();
            }
        }

        private class ApiRequest
        {
            public Model.QPX.Request.Request Request { get; set; }

            public ApiRequest(Model.QPX.Request.Request request)
            {
                Request = request;
            }
        }
    }
}
