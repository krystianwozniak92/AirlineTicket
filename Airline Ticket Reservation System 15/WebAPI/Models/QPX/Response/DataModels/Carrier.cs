namespace WebAPI.Models.QPX.Response.DataModels
{
    public class Carrier
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Carrier()
        {
            Kind = "qpxexpress#carrierData";
        }

        public Carrier(string code, string name)
            : this()
        {
            Code = code;
            Name = name;
        }
    }
}
