using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Passengers
    {
        public string Kind { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int InfantInLapCount { get; set; }
        public int InfantInSeatCount { get; set; }
        public int SeniorCount { get; set; }

        public Passengers()
        {
            Kind = "qpxexpress#passengerCounts";
        }

        public Passengers(
            int adultCount, int childCount,
            int infantInLapCount, int infantInSeatCount,
            int seniorCount)
            : this()
        {
            AdultCount = adultCount;
            ChildCount = childCount;
            InfantInLapCount = infantInLapCount;
            InfantInSeatCount = infantInSeatCount;
            SeniorCount = seniorCount;
        }
        public Passengers(JToken jPassengers)
            : this()
        {
            Kind = (string)jPassengers["kind"];
            AdultCount = (int)jPassengers["adultCount"];
            ChildCount = (int)jPassengers["childCount"];
            InfantInLapCount = (int)jPassengers["infantInLapCount"];
            InfantInSeatCount = (int)jPassengers["infantInSeatCount"];
            SeniorCount = (int)jPassengers["seniorCount"];
        }
    }
}
