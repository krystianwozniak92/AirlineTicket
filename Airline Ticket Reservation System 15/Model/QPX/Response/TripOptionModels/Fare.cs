using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Fare
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public string Carrier { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string BasisCode { get; set; }
        public bool Private { get; set; }

        public Fare()
        {
            Kind = "qpxexpress#fareInfo";
        }

        public Fare(
            bool @private, string basisCode, string destination,
            string origin, string carrier, string id)
            : this()
        {
            Private = @private;
            BasisCode = basisCode;
            Destination = destination;
            Origin = origin;
            Carrier = carrier;
            ID = id;
        }

        public Fare(JToken jFare)
            : this()
        {
            Kind = (string)jFare["kind"];
            ID = (string)jFare["iD"];
            Carrier = (string)jFare["carrier"];
            Origin = (string)jFare["origin"];
            Destination = (string)jFare["destination"];
            BasisCode = (string)jFare["basisCode"];
            Private = (bool)jFare["private"];
        }
    }
}
