using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Request
{
    public class Request
    {
        public string MaxPrice { get; set; }
        public string SaleCountry { get; set; }
        public bool? Refundable { get; set; }
        public int Solutions { get; set; }

        public Passengers Passengers { get; set; }
        public List<Slice> Slice { get; set; }

        public Request()
        {
            MaxPrice = "EUR000.00";
            SaleCountry = "XX";
            Refundable = false;
            Solutions = 0;

            Passengers = new Passengers();
            Slice = new List<Slice>();
        }

        public Request(string json)
            : this()
        {
            JObject jObject = JObject.Parse(json);
            JToken jRequest = jObject["request"];
            JToken jPassengers = jRequest["passengers"];
            JToken[] jSlices = jRequest["slice"].ToArray();

            MaxPrice = (string)jRequest["maxPrice"];
            SaleCountry = (string)jRequest["saleCountry"];
            Refundable = (bool?)jRequest["refundable"];
            Solutions = (int)jRequest["solutions"];

            foreach (var jSlice in jSlices)
                Slice.Add(new Slice(jSlice));

            Passengers = new Passengers(jPassengers);
        }

        public Request(
            List<Slice> slice, Passengers passengers,
            int solutions, bool refundable,
            string saleCountry, string maxPrice)
            : this()
        {
            Slice = slice;
            Passengers = passengers;
            Solutions = solutions;
            Refundable = refundable;
            SaleCountry = saleCountry;
            MaxPrice = maxPrice;
        }
    }
}
