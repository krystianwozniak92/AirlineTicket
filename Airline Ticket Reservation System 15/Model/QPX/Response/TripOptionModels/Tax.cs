using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Tax
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public string ChangeType { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string SalePrice { get; set; }

        public Tax()
        {
            Kind = "";
        }

        public Tax(
            string salePrice, string country, string code,
            string changeType, string id)
            : this()
        {
            SalePrice = salePrice;
            Country = country;
            Code = code;
            ChangeType = changeType;
            ID = id;
        }

        public Tax(JToken jTax)
            : this()
        {
            Kind = (string)jTax["kind"];
            ID = (string)jTax["iD"];
            ChangeType = (string)jTax["changeType"];
            Code = (string)jTax["code"];
            Country = (string)jTax["country"];
            SalePrice = (string)jTax["salePrice"];
        }
    }
}
