using System.Collections.Generic;
using System.Linq;
using Helpers;
using Model.QPX.Response.DataModels;
using Model.QPX.Response.TripOptionModels;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response
{
    public class Trips
    {
        public string Kind { get; set; }
        public string RequestID { get; set; }

        public Data Data { get; set; }
        public List<TripOption> TripOption { get; set; }

        public Trips()
        {
            Kind = "qpxexpress#tripOptions";
            RequestID = RandomHelper.GetRandomString(22);

            Data = new Data();
            TripOption = new List<TripOption>();
        }

        public Trips(List<TripOption> tripOption, Data data)
            : this()
        {
            TripOption = tripOption;
            Data = data;
        }

        public Trips(JToken jTrips)
            : this()
        {
            JToken jData = jTrips["data"];
            JToken[] jTripOptions = jTrips["tripOption"].ToArray();

            Kind = (string)jTrips["kind"];
            Kind = (string)jTrips["requestID"];

            Data = new Data(jData);
            foreach (var jTripOption in jTripOptions)
            {
                TripOption.Add(new TripOption(jTripOption));
            }
        }
    }
}
