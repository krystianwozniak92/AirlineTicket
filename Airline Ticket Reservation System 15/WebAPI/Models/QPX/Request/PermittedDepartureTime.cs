using Newtonsoft.Json.Linq;

namespace WebAPI.Models.QPX.Request
{
    public class PermittedDepartureTime
    {
        public string Kind { get; set; }
        public string EarliestTime { get; set; }
        public string LatestTime { get; set; }

        public PermittedDepartureTime()
        {
            Kind = "qpxexpress#timeOfDayRange";
        }

        public PermittedDepartureTime(JToken jPermittedDepartureTime) : this()
        {
            EarliestTime = (string) jPermittedDepartureTime["earliestTime"];
            LatestTime = (string)jPermittedDepartureTime["latestTime"];
        }

        public PermittedDepartureTime(
            string latestTime, string earliestTime,
            string kind) : this()
        {
            LatestTime = latestTime;
            EarliestTime = earliestTime;
            Kind = kind;
        }
    }
}
