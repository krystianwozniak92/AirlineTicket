namespace WebAPI.Models.QPX.Response.DataModels
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
    }
}
