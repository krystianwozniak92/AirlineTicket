namespace WebAPI.Models.QPX.Response.TripOptionModels
{
    public class Flight
    {
        public string Carrier { get; set; }
        public string Number { get; set; }
        public string Attribute { get; set; }

        public Flight()
        {
        }

        public Flight(string carrier, string number,
            string attribute) : this()
        {
            Carrier = carrier;
            Number = number;
            Attribute = attribute;
        }
    }
}
