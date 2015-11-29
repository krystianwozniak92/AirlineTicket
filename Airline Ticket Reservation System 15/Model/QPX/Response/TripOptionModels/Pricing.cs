using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Pricing
    {
        public string Kind { get; set; }
        public string SaleFareTotal { get; set; }
        public string SaleTaxTotal { get; set; }
        public string SaleTotal { get; set; }
        public string FareCalculation { get; set; }
        public string LatestTicketingTime { get; set; }
        public string Ptc { get; set; }
        public bool Refundable { get; set; }

        public List<Fare> Fare { get; set; }
        public List<SegmentPricing> SegmentPricing { get; set; }
        public Passengers Passengers { get; set; }
        public List<Tax> Tax { get; set; }

        public Pricing()
        {
            Kind = "qpxexpress#pricingInfo";
            Fare = new List<Fare>();
            SegmentPricing = new List<SegmentPricing>();
            Passengers = new Passengers();
            Tax = new List<Tax>();
        }

        public Pricing(
            string kind, string saleFareTotal, string saleTaxTotal, string saleTotal,
            string fareCalculation, string latestTicketingTime, string ptc,
            bool refundable, List<Fare> fare,
            List<SegmentPricing> segmentPricing,
            Passengers passengers, List<Tax> tax) : this()
        {
            Kind = kind;
            SaleFareTotal = saleFareTotal;
            SaleTaxTotal = saleTaxTotal;
            SaleTotal = saleTotal;
            FareCalculation = fareCalculation;
            LatestTicketingTime = latestTicketingTime;
            Ptc = ptc;
            Refundable = refundable;
            Fare = fare;
            SegmentPricing = segmentPricing;
            Passengers = passengers;
            Tax = tax;
        }

        public Pricing(JToken jPricing) : this()
        {
            JToken[] jFares = jPricing["fare"].ToArray();
            JToken[] jSegmentPricings = jPricing["segmentPricing"].ToArray();
            JToken jPassengers = jPricing["passengers"];
            JToken[] jTaxes = jPricing["tax"].ToArray();

            Kind = (string)jPricing["kind"];
            SaleFareTotal = (string)jPricing["saleFareTotal"];
            SaleTaxTotal = (string)jPricing["saleTaxTotal"];
            SaleTotal = (string)jPricing["saleTotal"];
            FareCalculation = (string)jPricing["fareCalculation"];
            LatestTicketingTime = (string)jPricing["latestTicketingTime"];
            Ptc = (string)jPricing["ptc"];
            Refundable = (bool)jPricing["refundable"];

            foreach (var jFare in jFares)
            {
                Fare.Add(new Fare(jFare));
            }

            foreach (var jSegmentPricing in jSegmentPricings)
            {
                SegmentPricing.Add(new SegmentPricing(jSegmentPricing));
            }

            Passengers = new Passengers(jPassengers);

            foreach (var jTax in jTaxes)
            {
                Tax.Add(new Tax(jTax));
            }
        }
    }
}
