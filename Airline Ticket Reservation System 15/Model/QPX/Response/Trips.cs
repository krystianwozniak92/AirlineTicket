using System.Collections.Generic;
using Helpers;
using Model.QPX.Response.DataModels;
using Model.QPX.Response.TripOptionModels;

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

        public Trips(List<TripOption> tripOption, Data data) : this()
        {
            TripOption = tripOption;
            Data = data;
        }
    }
}
