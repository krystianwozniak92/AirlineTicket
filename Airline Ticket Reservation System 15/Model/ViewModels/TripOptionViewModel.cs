namespace Model.ViewModels
{
    public class TripOptionViewModel
    {
        public TripOptionViewModel()
        {
            FlightViewModels = new FlightViewModels();
        }

        public FlightViewModels FlightViewModels { get; set; }
        public decimal FullPrice { get; set; }
    }
}
