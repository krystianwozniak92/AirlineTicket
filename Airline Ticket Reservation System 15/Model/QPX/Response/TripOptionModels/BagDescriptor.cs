using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class BagDescriptor
    {
        public string Kind { get; set; }
        public string CommercialName { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string SubCode { get; set; }

        public BagDescriptor()
        {

        }

        public BagDescriptor(string commercialName, int count,
            string description, string subCode) : this()
        {
            CommercialName = commercialName;
            Count = count;
            Description = description;
            SubCode = subCode;
        }

        public BagDescriptor(JToken jBagDescriptor)
        {
            Kind = (string) jBagDescriptor["kind"];
            CommercialName = (string)jBagDescriptor["commercialName"];
            Count = (int)jBagDescriptor["count"];
            Description = (string)jBagDescriptor["description"];
            SubCode = (string)jBagDescriptor["subCode"];
        }
    }
}
