using Newtonsoft.Json.Linq;

namespace WebAPI.Models.QPX.Request
{
    public class Passengers
    {
        public string Kind { get; set; }
        public int? AdultCount { get; set; }
        public int? ChildCount { get; set; }
        public int? InfantInLapCount { get; set; }
        public int? InfantInSeatCount { get; set; }
        public int? SeniorCount { get; set; }

        public Passengers()
        {
            Kind = "qpxexpress#passengerCounts";
        }

        public Passengers(JToken tokenPassengers) : this()
        {
            AdultCount = (int?)tokenPassengers["adultCount"];
            ChildCount = (int?)tokenPassengers["childCount"];
            InfantInLapCount = (int?)tokenPassengers["infantInLapCount"];
            InfantInSeatCount = (int?)tokenPassengers["infantInSeatCount"];
            SeniorCount = (int?)tokenPassengers["seniorCount"];
        }

        public Passengers(
            int seniorCount, int infantInSeatCount,
            int infantInLapCount, int childCount,
            int adultCount, string kind) : this()
        {
            SeniorCount = seniorCount;
            InfantInSeatCount = infantInSeatCount;
            InfantInLapCount = infantInLapCount;
            ChildCount = childCount;
            AdultCount = adultCount;
            Kind = kind;
        }
    }
}
