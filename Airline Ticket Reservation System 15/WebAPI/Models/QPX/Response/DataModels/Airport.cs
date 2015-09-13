namespace WebAPI.Models.QPX.Response.DataModels
{
    public class Airport
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public Airport()
        {
            Kind = "qpxexpress#airportData";
        }

        public Airport(string code, string city, string name)
            : this()
        {
            Code = code;
            City = city;
            Name = name;
        }
    }
}
