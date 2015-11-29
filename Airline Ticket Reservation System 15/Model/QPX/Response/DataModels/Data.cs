using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.DataModels
{
    public class Data
    {
        public string Kind { get; set; }

        public List<City> City { get; set; }
        public List<Airport> Airport { get; set; }
        public List<Aircraft> Aircraft { get; set; }
        public List<Tax> Tax { get; set; }
        public List<Carrier> Carrier { get; set; }

        public Data()
        {
            Kind = "qpxexpress#data";

            City = new List<City>();
            Airport = new List<Airport>();
            Aircraft = new List<Aircraft>();
            Tax = new List<Tax>();
            Carrier = new List<Carrier>();
        }

        public Data(List<City> city, List<Airport> airport,
            List<Carrier> carrier, List<Aircraft> aircraft,
            List<Tax> tax)
            : this()
        {
            City = city;
            Airport = airport;
            Carrier = carrier;
            Aircraft = aircraft;
            Tax = tax;
        }

        public Data(JToken jData)
            : this()
        {
            JToken[] jCities = jData["city"].ToArray();
            JToken[] jAirports = jData["airport"].ToArray();
            JToken[] jAircrafts = jData["aircraft"].ToArray();
            JToken[] jTaxes = jData["tax"].ToArray();
            JToken[] jCarriers = jData["carrier"].ToArray();

            Kind = (string)jData["kind"];

            foreach (var jCity in jCities)
            {
                City.Add(new City(jCity));
            }

            foreach (var jAirport in jAirports)
            {
                Airport.Add(new Airport(jAirport));
            }

            foreach (var jAircraft in jAircrafts)
            {
                Carrier.Add(new Carrier(jAircraft));
            }

            foreach (var jTax in jTaxes)
            {
                Aircraft.Add(new Aircraft(jTax));
            }

            foreach (var jCarrier in jCarriers)
            {
                Tax.Add(new Tax(jCarrier));
            }
        }
    }
}
