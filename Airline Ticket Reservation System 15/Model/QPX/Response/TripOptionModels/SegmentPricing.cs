using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class SegmentPricing
    {
        public string Kind { get; set; }
        public string FareID { get; set; }
        public string SegmentID { get; set; }

        public List<FreeBaggageOption> FreeBaggageOption { get; set; }

        public SegmentPricing()
        {
            FreeBaggageOption = new List<FreeBaggageOption>();
        }

        public SegmentPricing(
            List<FreeBaggageOption> freeBaggageOption,
            string segmentId, string fareId)
            : this()
        {
            FreeBaggageOption = freeBaggageOption;
            SegmentID = segmentId;
            FareID = fareId;
        }

        public SegmentPricing(JToken jSegmentPricing)
            : this()
        {
            JToken[] jFreeBaggageOptions = jSegmentPricing["freeBagageOption"].ToArray();

            Kind = (string)jSegmentPricing["kind"];
            FareID = (string)jSegmentPricing["fareID"];
            SegmentID = (string)jSegmentPricing["segmentID"];

            foreach (var jFreeBaggageOption in jFreeBaggageOptions)
            {
                FreeBaggageOption.Add(new FreeBaggageOption(jFreeBaggageOption));
            }
        }
    }
}
