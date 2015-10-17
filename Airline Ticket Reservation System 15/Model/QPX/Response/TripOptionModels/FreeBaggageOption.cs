using System.Collections.Generic;

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
            int kilos) : this()
        {
            BagDescriptor = bagDescriptor;
            Attribute = attribute;
            Pounds = pounds;
            KilosPerPiece = kilosPerPiece;
            Kilos = kilos;
        }
    }
}
