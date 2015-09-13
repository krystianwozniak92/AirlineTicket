namespace WebAPI.Models.QPX.Response.DataModels
{
    public class City
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }

        public City()
        {
            Kind = "qpxexpress#cityData";
        }

        public City(string code, string country, string name) : this()
        {
            Code = code;
            Country = country;
            Name = name;
        }
    }
}
