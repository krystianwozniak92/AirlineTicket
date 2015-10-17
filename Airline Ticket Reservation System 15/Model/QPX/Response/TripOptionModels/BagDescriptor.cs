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
    }
}
