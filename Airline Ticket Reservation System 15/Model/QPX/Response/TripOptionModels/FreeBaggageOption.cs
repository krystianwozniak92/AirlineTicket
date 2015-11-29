using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Model.QPX.Response.TripOptionModels
{
    public class FreeBaggageOption
    {
        public string Kind { get; set; }
        public int Kilos { get; set; }
        public int KilosPerPiece { get; set; }
        public int Pounds { get; set; }
        public string Attribute { get; set; }
        public int Pieces { get; set; }
        public List<BagDescriptor> BagDescriptor { get; set; }

        public FreeBaggageOption()
        {
            BagDescriptor = new List<BagDescriptor>();
        }

        public FreeBaggageOption(List<BagDescriptor> bagDescriptor,
            string attribute, int pounds, int kilosPerPiece,
            int kilos)
            : this()
        {
            BagDescriptor = bagDescriptor;
            Attribute = attribute;
            Pounds = pounds;
            KilosPerPiece = kilosPerPiece;
            Kilos = kilos;
        }

        public FreeBaggageOption(JToken jFreeBaggageOption)
            : this()
        {
            JToken[] jBagDescriptors = jFreeBaggageOption["bagDescriptor"].ToArray();

            Kind = (string)jFreeBaggageOption["kind"];
            Kilos = (int)jFreeBaggageOption["kilos"];
            KilosPerPiece = (int)jFreeBaggageOption["kilosPerPiece"];
            Pounds = (int)jFreeBaggageOption["pounds"];
            Attribute = (string)jFreeBaggageOption["attribute"];
            Pieces = (int)jFreeBaggageOption["pieces"];

            foreach (var jBagDescriptor in jBagDescriptors)
            {
                BagDescriptor.Add(new BagDescriptor(jBagDescriptor));
            }
        }
    }
}
