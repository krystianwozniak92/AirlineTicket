using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.DataModels
{
    public class Aircraft
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Aircraft()
        {
            Kind = "qpxexpress#aircraftData";
        }

        public Aircraft(string code, string name)
            : this()
        {
            Code = code;
            Name = name;
        }

        public Aircraft(JToken jAircraft)
            : this()
        {
            Kind = (string)jAircraft["kind"];
            Code = (string)jAircraft["code"];
            Name = (string)jAircraft["name"];
        }
    }
}
