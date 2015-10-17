using System.Collections.Generic;

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
            List<Tax> tax) : this()
        {
            City = city;
            Airport = airport;
            Carrier = carrier;
            Aircraft = aircraft;
            Tax = tax;
        }
    }
}
