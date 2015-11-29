using Model.QPX.Interfaces;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response
{
    public class Response : IResponse
    {
        public string Kind { get; set; }
        
        public Trips Trips { get; set; }

        public Response()
        {
            Kind = "qpxExpress#tripsSearch";

            Trips = new Trips();
        }

        public Response(string json) : this()
        {
            JObject jObject = JObject.Parse(json);
            JToken jTrips = jObject["trips"];

            Kind = (string)jObject["kind"];

            Trips = new Trips(jTrips);
        }
    }
}
