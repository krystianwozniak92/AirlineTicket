using System.Collections.Generic;
using WebAPI.Models.QPX.Request;

namespace WebAPI.Helpers
{
    public static class PassengerHelper
    {
        public enum PassengerEnum
        {
            Adult,
            Child,
            InfantInLap,
            InfantInSeat,
            Senior,
        }

        public static IList<int?> GetPassengerArray(
            Models.QPX.Request.Passengers passengers)
        {
            var passengersList = new List<int?>()
            {
                passengers.AdultCount,
                passengers.ChildCount,
                passengers.InfantInLapCount,
                passengers.InfantInSeatCount,
                passengers.SeniorCount
            };

            return passengersList;
        }

        public static int TotalPassengersCount(JsonRequest request)
        {
            int passengersCount = 0;

            if (request.Request.Passengers.AdultCount != null)
                passengersCount += (int)request.Request.Passengers.AdultCount;

            if (request.Request.Passengers.ChildCount != null)
                passengersCount += (int)request.Request.Passengers.ChildCount;

            if (request.Request.Passengers.InfantInLapCount != null)
                passengersCount += (int)request.Request.Passengers.InfantInLapCount;

            if (request.Request.Passengers.InfantInSeatCount != null)
                passengersCount += (int)request.Request.Passengers.InfantInSeatCount;

            if (request.Request.Passengers.SeniorCount != null)
                passengersCount += (int)request.Request.Passengers.SeniorCount;

            return passengersCount;
        }
    }
}
