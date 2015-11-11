﻿namespace Model.ViewModels
{
    public class SearchFlightRequest
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public int[] PassengerCount { get; set; }
        public bool IsRoundTrip { get; set; }
        public bool IsNonStopPreferred { get; set; }
    }
}