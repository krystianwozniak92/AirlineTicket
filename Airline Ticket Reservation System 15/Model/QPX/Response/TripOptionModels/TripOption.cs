using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class TripOption
    {
        public string Kind { get; set; }
        public string SaleTotal { get; set; }
        public string ID { get; set; }

        public List<Slice> Slice { get; set; }
        public List<Pricing> Pricing { get; set; }

        public TripOption()
        {
            Kind = "qpxexpress#tripOption";
            Slice = new List<Slice>();
            Pricing = new List<Pricing>();
        }

        public TripOption
            (List<Pricing> pricing, List<Slice> slice,
            string id, string saleTotal)
            : this()
        {
            Pricing = pricing;
            Slice = slice;
            ID = id;
            SaleTotal = saleTotal;
        }

        public TripOption(JToken jTripOption)
            : this()
        {
            JToken[] jSlices = jTripOption["slice"].ToArray();
            JToken[] jPricings = jTripOption["pricing"].ToArray();

            Kind = (string)jTripOption["kind"];
            SaleTotal = (string)jTripOption["saleTotal"];
            ID = (string)jTripOption["iD"];

            foreach (var jSlice in jSlices)
            {
                Slice.Add(new Slice(jSlice));
            }

            foreach (var jPricing in jPricings)
            {
                Pricing.Add(new Pricing(jPricing));
            }
        }
    }
}
