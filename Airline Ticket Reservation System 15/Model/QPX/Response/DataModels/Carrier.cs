using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.DataModels
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

        public Carrier(JToken jCarrier)
            : this()
        {
            Kind = (string)jCarrier["kind"];
            Code = (string)jCarrier["code"];
            Name = (string)jCarrier["name"];
        }
    }
}
