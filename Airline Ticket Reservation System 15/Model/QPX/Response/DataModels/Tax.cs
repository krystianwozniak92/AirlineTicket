using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.DataModels
{
    public class Tax
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }

        public Tax()
        {
            Kind = "";
        }

        public Tax(string id, string name)
            : this()
        {
            ID = id;
            Name = name;
        }

        public Tax(JToken jTax)
            : this()
        {
            Kind = (string)jTax["kind"];
            ID = (string)jTax["iD"];
            Name = (string)jTax["name"];
        }
    }
}
