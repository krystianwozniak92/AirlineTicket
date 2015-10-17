using Newtonsoft.Json.Linq;

namespace Model.QPX.Request
{
    public class Slice
    {
        public string Kind { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public int? MaxStops { get; set; }
        public int? MaxConnectionDuration { get; set; }
        public string PrefferedCabin { get; set; }
        public string Alliance { get; set; }
        public string PermittedCarrier { get; set; }

        public PermittedDepartureTime PermittedDepartureTime { get; set; }

        public Slice()
        {
            Kind = "qpxexpress#sliceInput";

            PermittedDepartureTime = new PermittedDepartureTime();
        }

        public Slice(JToken jSlice) : this()
        {
            Origin = (string)jSlice["origin"];
            Destination = (string)jSlice["destination"];
            Date = (string)jSlice["date"];
            MaxStops = (int?)jSlice["maxStops"];
            MaxConnectionDuration = (int?)jSlice["maxConnectionDuration"];
            PrefferedCabin = (string)jSlice["prefferedCabin"];
            Alliance = (string)jSlice["alliance"];
            PermittedCarrier = (string)jSlice["permittedCarrier"];

            JToken jpermittedDepartureTime = jSlice["permittedDepartureTime"];

            if(jpermittedDepartureTime != null)
                PermittedDepartureTime = new PermittedDepartureTime(jpermittedDepartureTime);
        }

        public Slice(
            PermittedDepartureTime permittedDepartureTime,
            string permittedCarrier, string alliance,
            string prefferedCabin, int maxConnectionDuration,
            int maxStops, string date, string destination,
            string origin, string kind) : this()
        {
            PermittedDepartureTime = permittedDepartureTime;
            PermittedCarrier = permittedCarrier;
            Alliance = alliance;
            PrefferedCabin = prefferedCabin;
            MaxConnectionDuration = maxConnectionDuration;
            MaxStops = maxStops;
            Date = date;
            Destination = destination;
            Origin = origin;
            Kind = kind;
        }
    }
}
