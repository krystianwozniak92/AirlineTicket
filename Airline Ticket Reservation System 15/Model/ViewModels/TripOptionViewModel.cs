namespace Model.ViewModels
{
    public class TripOptionViewModel
    {
        public string FullPrice { get; set; }

        public TripOptionViewModel()
        {
            FlightViewModels = new FlightViewModels();
        }

        public FlightViewModels FlightViewModels { get; set; }
    }
}
