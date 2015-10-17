namespace Model.QPX.Response.DataModels
{
    public class Aircraft
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Aircraft()
        {
            Kind = "qpxexpress#aircraftData";
        }
        
        public Aircraft(string code, string name)
            : this()
        {
            Code = code;
            Name = name;
        }
    }
}
