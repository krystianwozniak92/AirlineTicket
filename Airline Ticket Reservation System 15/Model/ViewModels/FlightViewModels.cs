using System.Collections.Generic;

namespace Model.ViewModels
{
    public class FlightViewModels
    {
        public FlightViewModels()
        {
            FlightViewModelCollection = new List<FlightViewModel>();
        }

        public ICollection<FlightViewModel> FlightViewModelCollection { get; set; }
    }
}
