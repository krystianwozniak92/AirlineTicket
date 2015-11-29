using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

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

        public Slice(JToken jSlice)
            : this()
        {
            JToken[] jSegments = jSlice["segment"].ToArray();

            Kind = (string)jSlice["kind"];
            Duration = (int)jSlice["duration"];

            foreach (var jSegment in jSegments)
            {
                Segment.Add(new Segment(jSegment));
            }
        }
    }
}
