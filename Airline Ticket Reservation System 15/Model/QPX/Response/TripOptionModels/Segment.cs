using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class Segment
    {
        public string Kind { get; set; }
        public int Duration { get; set; }
        public string ID { get; set; }
        public string Cabin { get; set; }
        public string BookingCode { get; set; }
        public int BookingCodeCount { get; set; }
        public string MarriedSegmentGroup { get; set; }
        public bool SubjectToGovernmentApproval { get; set; }
        public int ConnectionDuration { get; set; }

        public List<Leg> Leg { get; set; }
        public Flight Flight { get; set; }

        public Segment()
        {
            Kind = "qpxexpress#segmentInfo";

            Leg = new List<Leg>();
            Flight = new Flight();
        }

        public Segment(
            int duration, string id,
            string cabin, string bookingCode,
            int bookingCodeCount, string marriedSegmentGroup,
            bool subjectToGovernmentApproval,
            int connectionDuration, List<Leg> leg,
            Flight flight)
            : this()
        {
            Duration = duration;
            ID = id;
            Cabin = cabin;
            BookingCode = bookingCode;
            BookingCodeCount = bookingCodeCount;
            MarriedSegmentGroup = marriedSegmentGroup;
            SubjectToGovernmentApproval = subjectToGovernmentApproval;
            ConnectionDuration = connectionDuration;
            Leg = leg;
            Flight = flight;
        }

        public Segment(JToken jSegment)
            : this()
        {
            JToken[] jLegs = jSegment["leg"].ToArray();
            JToken jFlight = jSegment["flight"];

            Kind = (string)jSegment["kind"];
            Duration = (int)jSegment["duration"];
            ID = (string)jSegment["iD"];
            Cabin = (string)jSegment["cabin"];
            BookingCode = (string)jSegment["bookingCode"];
            BookingCodeCount = (int)jSegment["bookingCodeCount"];
            MarriedSegmentGroup = (string)jSegment["marriedSegmentGroup"];
            SubjectToGovernmentApproval = (bool)jSegment["subjectToGovernmentApproval"];
            ConnectionDuration = (int)jSegment["connectionDuration"];

            foreach (var jLeg in jLegs)
            {
                Leg.Add(new Leg(jLeg));
            }

            Flight = new Flight(jFlight);
        }
    }
}
