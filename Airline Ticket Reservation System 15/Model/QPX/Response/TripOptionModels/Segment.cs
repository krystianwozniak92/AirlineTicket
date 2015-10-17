using System.Collections.Generic;

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
            Flight flight) : this()
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
    }
}
