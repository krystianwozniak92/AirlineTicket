using System.Collections.Generic;

namespace Model.QPX.Response.TripOptionModels
{
    public class Slice
    {
        public string Kind { get; set; }
        public int Duration { get; set; }

        public List<Segment> Segment { get; set; }

        public Slice()
        {
            Kind = "qpxexpress#sliceInfo";
            Segment = new List<Segment>();
        }

        public Slice(List<Segment> segment, int duration)
            : this()
        {
            Segment = segment;
            Duration = duration;
        }
    }
}
