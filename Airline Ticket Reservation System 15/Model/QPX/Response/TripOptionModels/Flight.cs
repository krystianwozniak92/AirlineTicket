using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Flight
    {
        public string Carrier { get; set; }
        public string Number { get; set; }
        public string Attribute { get; set; }

        public Flight()
        {
        }

        public Flight(string carrier, string number,
            string attribute) : this()
        {
            Carrier = carrier;
            Number = number;
            Attribute = attribute;
        }

        public Flight(JToken jLeg) : this()
        {
            Carrier = (string)jLeg["carrier"];
            Number = (string)jLeg["number"];
            Attribute = (string)jLeg["attribute"];
        }
    }
}
