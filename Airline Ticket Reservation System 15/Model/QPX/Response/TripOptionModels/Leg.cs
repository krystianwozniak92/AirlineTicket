using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
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

        public Leg(JToken jLeg)
            : this()
        {
            ID = (string)jLeg["iD"];
            Aircraft = (string)jLeg["aircraft"];
            ArrivalTime = (string)jLeg["arrivalTime"];
            DepartureTime = (string)jLeg["departureTime"];
            Origin = (string)jLeg["origin"];
            Destination = (string)jLeg["destination"];
            OriginTerminal = (string)jLeg["originTerminal"];
            DestinationTerminal = (string)jLeg["destinationTerminal"];
            Attribute = (string)jLeg["attribute"];
            Duration = (int)jLeg["duration"];
            Number = (string)jLeg["number"];
            OperatingDisclosure = (string)jLeg["operatingDisclosure"];
            Mileage = (int)jLeg["mileage"];
            Meal = (string)jLeg["meal"];
            Secure = (bool)jLeg["secure"];
            ConnectionDuration = (int)jLeg["connectionDuration"];
            ChangePlane = (bool)jLeg["changePlane"];
            OnTimePerformance = (int)jLeg["onTimePerformance"];
        }
    }
}
