using System;
using System.Collections.Generic;
using System.Linq;
using Model.QPX.Response;

namespace Model.ViewModels
{
    public class TripOptionViewModels
    {
        public TripOptionViewModels()
        {
            TripOptionViewModelCollection = new List<TripOptionViewModel>();
        }

        public TripOptionViewModels(Response response)
            : this()
        {
            foreach (var tripOption in response.Trips.TripOption)
            {
                TripOptionViewModel tripOptionViewModel = new TripOptionViewModel();
                tripOptionViewModel.FullPrice = tripOption.SaleTotal;

                foreach (var slice in tripOption.Slice)
                {
                    FlightViewModel flight = new FlightViewModel();
                    var firstSegment = slice.Segment.First();
                    var lastSegment = slice.Segment.Last();

                    flight.Departure = firstSegment.Leg[0].Origin;
                    flight.Arrival = lastSegment.Leg[0].Destination;
                    flight.DepartureDate = DateTime.Parse(firstSegment.Leg[0].DepartureTime);
                    flight.ArrivalDate = DateTime.Parse(lastSegment.Leg[0].DepartureTime);

                    tripOptionViewModel.FlightViewModels.FlightViewModelCollection.Add(flight);
                }
                TripOptionViewModelCollection.Add(tripOptionViewModel);
            }
        }

        public ICollection<TripOptionViewModel> TripOptionViewModelCollection { get; set; }
    }
}
