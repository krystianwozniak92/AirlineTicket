using System.Collections.Generic;

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
            string segmentId, string fareId) : this()
        {
            FreeBaggageOption = freeBaggageOption;
            SegmentID = segmentId;
            FareID = fareId;
        }
    }
}
