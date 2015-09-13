namespace WebAPI.Models.QPX.Response.TripOptionModels
{
    public class Leg
    {
        public string ID { get; set; }
        public string Aircraft { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string OriginTerminal { get; set; }
        public string DestinationTerminal { get; set; }
        public string Attribute { get; set; }
        public int Duration { get; set; }
        public string Number { get; set; }
        public string OperatingDisclosure { get; set; }
        public int Mileage { get; set; }
        public string Meal { get; set; }
        public bool Secure { get; set; }
        public int ConnectionDuration { get; set; }
        public bool ChangePlane { get; set; }
        public int OnTimePerformance { get; set; }

        public Leg()
        {

        }

        public Leg(
           string id, string aircraft, string arrivalTime,
           string departureTime, string origin, string destination,
           string originTerminal, string destinationTerminal,
           string attribute, int duration, string number,
           string operatingDisclosure, int mileage, string meal,
           bool secure, int connectionDuration, bool changePlane)
        {
            ID = id;
            Aircraft = aircraft;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            Origin = origin;
            Destination = destination;
            OriginTerminal = originTerminal;
            DestinationTerminal = destinationTerminal;
            Attribute = attribute;
            Duration = duration;
            Number = number;
            OperatingDisclosure = operatingDisclosure;
            Mileage = mileage;
            Meal = meal;
            Secure = secure;
            ConnectionDuration = connectionDuration;
            ChangePlane = changePlane;
        }
    }
}
