using System.Collections.Generic;

namespace WebAPI.Models.QPX.Response.TripOptionModels
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
            string id, string saleTotal) : this()
        {
            Pricing = pricing;
            Slice = slice;
            ID = id;
            SaleTotal = saleTotal;
        }
    }
}
