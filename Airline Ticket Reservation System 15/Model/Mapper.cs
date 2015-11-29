using System;
using Model.QPX.Request;
using Model.QPX.Response;
using Model.ViewModels;

namespace Model
{
    public class Mapper
    {
        public static TDestination To<TSource, TDestination>(TSource model)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDestination>();
            return AutoMapper.Mapper.Map<TSource, TDestination>(model);
        }

        public static Request ToQpxRequest(SearchFlightRequest request)
        {
            var qpxRequest = new Request();

            qpxRequest.Solutions = 10;
            qpxRequest.Passengers.AdultCount = request.Adults;
            qpxRequest.Passengers.ChildCount = request.Childrens;
            qpxRequest.Passengers.InfantInLapCount = request.InfantsInLap;
            qpxRequest.Passengers.InfantInSeatCount = request.InfantsInSeat;
            qpxRequest.Passengers.SeniorCount = request.Seniors;

            Slice departure = new Slice();
            departure.Origin = request.Departure;
            departure.Destination = request.Arrival;
            departure.Date = request.DepartureDate;
            qpxRequest.Slice.Add(departure);

            if (request.IsRoundTrip)
            {
                Slice arrival = new Slice();
                arrival.Origin = request.Arrival;
                arrival.Destination = request.Departure;
                arrival.Date = request.ArrivalDate;
                qpxRequest.Slice.Add(arrival);
            }

            return qpxRequest;
        }

        public static TripOptionViewModels ToTripOptionViewModels(Response response)
        {
            var tripOptionViewModels = new TripOptionViewModels();
            foreach (var responseTripOption in response.Trips.TripOption)
            {
                var tripOptionViewModel = new TripOptionViewModel();;
                for(int s = 0; s < responseTripOption.Slice.Count; s++)
                {
                    var slice = responseTripOption.Slice[s];
                    var flightViewModels = new FlightViewModels();
                    for(int seg = 0; seg < slice.Segment.Count; seg++)
                    {
                        var segment = slice.Segment[seg];
                        var leg = segment.Leg[0];                // MyFlights always has one leg
                        var flightViewModel = new FlightViewModel();
                        flightViewModel.Departure = leg.Origin;
                        flightViewModel.Arrival = leg.Destination;
                        var departureDate = DateTime.ParseExact(leg.DepartureTime,
                            "yyyy-mm-dd hh:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture);

                        flightViewModel.DepartureDate = departureDate;
                        flightViewModel.ArrivalDate = departureDate.AddMinutes(leg.Duration);
                        flightViewModels.FlightViewModelCollection.Add(flightViewModel);
                    }
                    tripOptionViewModel.FlightViewModels = flightViewModels;
                }
                tripOptionViewModels.TripOptionViewModelCollection.Add(tripOptionViewModel);
            }

            return tripOptionViewModels;
        }

    }
}
