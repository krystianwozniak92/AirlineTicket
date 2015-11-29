namespace Model.ViewModels
{
    public class SearchFlightRequest
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public bool IsRoundTrip { get; set; }
        public bool IsNonStopPreferred { get; set; }
        public int Adults { get; set; }
        public int Childrens { get; set; }
        public int Seniors { get; set; }
        public int InfantsInSeat { get; set; }
        public int InfantsInLap { get; set; }
    }
}