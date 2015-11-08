using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Converters.DbToQPX;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Models.FlightsDb;
using WebAPI.Models.Interfaces;
using Model.QPX.Interfaces;
using Model.QPX.Response;
using Model.QPX.Response.TripOptionModels;
using WebAPI.Repository;
using Passengers = Model.QPX.Request.Passengers;
using Tax = Model.QPX.Response.TripOptionModels.Tax;


namespace WebAPI.Converters
{
    public static class QpxConverter
    {
        public static Response MultipleSlicesToResponse(List<IEnumerable<IInDirectFlight>> slices,
            Passengers passengers, int maxSolutions)
        {
            var response = new Response();
            var solutions = new List<Solution>();
            const int minimuHoursChangePlane = 1;

            // Build all possible solutions from 
            for (var i = 0; i < slices.ElementAt(0).Count(); i++)
            {
                for (var y = 0; y < slices.ElementAt(1).Count(); y++)
                {
                    var inDirectFlightSlice1 = slices[0].ElementAt(i).Flights.Last();
                    var inDirectFlightSlice2 = slices[1].ElementAt(y).Flights.First();

                    if (inDirectFlightSlice1.Date.
                        AddHours(minimuHoursChangePlane).
                        AddMinutes(inDirectFlightSlice1.Route.Duration) >= inDirectFlightSlice2.Date) continue;
                    var tempSolution = new Solution();
                    tempSolution.InDirectFlights.Add(slices[0].ElementAt(i));
                    tempSolution.InDirectFlights.Add(slices[1].ElementAt(y));
                    solutions.Add(tempSolution);
                }
            }

            // Sort solutons by price
            solutions = solutions.OrderBy(s => s.TotalBasePrice).ToList();

            // Cut to maximum number of solutions
            if (solutions.Count > maxSolutions)
                solutions.RemoveRange(maxSolutions, solutions.Count - maxSolutions);

            //solutions.ForEach(Console.WriteLine);

            // Add data to Response
            AddDistinctDataValues(solutions, response);

            // Add TripOption's to Response
            AddTripOption(solutions, passengers, response);

            return response;
        }

        private static void AddDistinctDataValues(
            IEnumerable<Solution> solutions,
            IResponse response)
        {
            // Add data object to Response.
            List<City> distinctCities = new List<City>();
            List<Airport> distinctAirports = new List<Airport>();
            List<Aircraft> distinctAircrafts = new List<Aircraft>();
            List<RouteTax> distinctRouteTaxs = new List<RouteTax>();
            List<Carrier> distinctCarriers = new List<Carrier>();

            foreach (var solution in solutions)
            {
                foreach (var inDirectFlight in solution.InDirectFlights)
                {
                    foreach (var flight in inDirectFlight.Flights)
                    {
                        // Add all distinct cities
                        if (!distinctCities.Contains(flight.Route.DepartureAirport.City))
                            distinctCities.Add(flight.Route.DepartureAirport.City);
                        if (!distinctCities.Contains(flight.Route.DestinationAirport.City))
                            distinctCities.Add(flight.Route.DestinationAirport.City);

                        // Add all distinct airports
                        if (!distinctAirports.Contains(flight.Route.DepartureAirport))
                            distinctAirports.Add(flight.Route.DepartureAirport);
                        if (!distinctAirports.Contains(flight.Route.DestinationAirport))
                            distinctAirports.Add(flight.Route.DestinationAirport);

                        // Add all distinct aircrafts
                        if (!distinctAircrafts.Contains(flight.Aircraft))
                            distinctAircrafts.Add(flight.Aircraft);

                        // Add all distinct taxes
                        foreach (var routeTax in flight.Route.RouteTaxes)
                        {
                            if (!distinctRouteTaxs.Contains(routeTax))
                                distinctRouteTaxs.Add(routeTax);
                        }

                        // Add all distinct carriers
                        if (!distinctCarriers.Contains(flight.Aircraft.Carrier))
                            distinctCarriers.Add(flight.Aircraft.Carrier);
                    }
                }
            }

            distinctCities.Sort((x, y) => string.Compare(x.IATA, y.IATA));
            distinctAirports.Sort((x, y) => string.Compare(x.IATA, y.IATA));
            distinctAircrafts.Sort((x, y) => string.Compare(x.Code, y.Code));
            distinctRouteTaxs.Sort((x, y) => string.Compare(x.IdNumber, y.IdNumber));
            distinctCarriers.Sort((x, y) => string.Compare(x.Code, y.Code));

            // Add distinct cities/airports.aircrafts/taxs and carriers to response
            foreach (var distinctCity in distinctCities)
            {
                response.Trips.Data.City.Add(new Model.QPX.Response.DataModels.City
                {
                    Code = distinctCity.IATA,
                    Country = distinctCity.Country.Name,
                    Name = distinctCity.Name
                });
            }

            foreach (var distinctAirport in distinctAirports)
            {
                response.Trips.Data.Airport.Add(new Model.QPX.Response.DataModels.Airport()
                {
                    Code = distinctAirport.IATA,
                    City = distinctAirport.City.Name,
                    Name = distinctAirport.Name
                });
            }

            foreach (var distinctAircraft in distinctAircrafts)
            {
                response.Trips.Data.Aircraft.Add(new Model.QPX.Response.DataModels.Aircraft()
                {
                    Code = distinctAircraft.Code,
                    Name = distinctAircraft.Name
                });
            }

            foreach (var distinctRouteTax in distinctRouteTaxs)
            {

                response.Trips.Data.Tax.Add(new Model.QPX.Response.DataModels.Tax()
                {
                    ID = distinctRouteTax.IdNumber,
                    Name = RouteTaxHelper.GetFullTaxName(distinctRouteTax),
                });
                
            }

            foreach (var distinctCarrier in distinctCarriers)
            {
                response.Trips.Data.Carrier.Add(new Model.QPX.Response.DataModels.Carrier()
                {
                    Code = distinctCarrier.Code,
                    Name = distinctCarrier.Name
                });
            }
        }

        private static void AddTripOption(
            ICollection<Solution> solutions,
            Passengers passengers,
            Response response)
        {
            // Add TriOption to Response
            response.Trips.TripOption = new List<TripOption>();

            // Add Slices to Response
            AddSlicesToResponse(solutions, response);

            // Add Pricing information to Response
            AddPricingsToResponse(solutions, passengers, response);
        }

        private static void AddSlicesToResponse(
            IEnumerable<Solution> solutions,
            IResponse response)
        {
            // For each solution
            foreach (var solution in solutions)
            {
                var tempTripOption = new TripOption();
                var tempSlices = new List<Slice>();

                // Simulate trip id string.
                tempTripOption.ID = RandomHelper.GetRandomString();

                // Foreach slice/InDirectFlight in specific solution
                foreach (var slice in solution.InDirectFlights)
                {
                    var tempSlice = new Slice();
                    var tempSegments = new List<Segment>();

                    tempSlice.Duration = slice.TotalDuration;
                    for (var i = 0; i < slice.Flights.Count; i++)
                    {
                        var flight = slice.Flights.ElementAt(i);
                        var tempSegment = new Segment
                        {
                            Duration = flight.Route.Duration,
                            Flight =
                            {
                                Carrier = flight.Aircraft.Carrier.Code,
                                Number = flight.FlightID.ToString()
                            },
                            ID = RandomHelper.GetRandomString(16),
                            Cabin = flight.Aircraft.Cabin.Name,
                            BookingCode = "S",
                            BookingCodeCount = flight.SeatCountLeft,
                            MarriedSegmentGroup = "0",
                            Leg =
                            {
                                new Leg
                                {
                                    ID = RandomHelper.GetRandomString(16),
                                    Aircraft = flight.Aircraft.Code,
                                    DepartureTime = flight.Date.ToString("s"),
                                    ArrivalTime = FlightHelper.GetFlightArrivalDate(flight).ToString("s"),
                                    Origin = flight.Route.DepartureAirport.IATA,
                                    Destination = flight.Route.DestinationAirport.IATA,
                                    DestinationTerminal = "Terminal C",
                                    Duration = flight.Route.Duration,
                                    Mileage = flight.Route.Distance,
                                    Meal = flight.Meal.Name,
                                    Secure = true
                                }
                            }
                        };

                        // If it's not last flight in this slice then
                        if (i < slice.Flights.Count - 1)
                        {
                            // Calculate change plane time to next flight
                            tempSegment.ConnectionDuration = (int)FlightHelper.GetChangeTransferTimeSpan(flight,
                                slice.Flights.ElementAt(i + 1)).TotalMinutes;
                        }
                        else
                            tempSegment.ConnectionDuration = 0;

                        tempSegments.Add(tempSegment);
                        tempSlice.Segment = tempSegments;
                    }

                    tempSlices.Add(tempSlice);
                }
                tempTripOption.Slice = tempSlices;
                response.Trips.TripOption.Add(tempTripOption);
            }
        }

        private static void AddPricingsToResponse(
            ICollection<Solution> solutions,
            Passengers passengers,
            Response response)
        {
            var passengersCount = PassengerHelper.GetPassengerArray(passengers);
            RouteTaxRepository routeTaxRepository = new RouteTaxRepository();

            var tripOptionIndex = 0;
            // For each solution (Trip Option)
            foreach (var solution in solutions)
            {           
                var tempPricings = new List<Pricing>();
                
                // For each passenger type
                for (var i = 0; i < passengersCount.Count; i++)
                {
                    if (passengersCount[i] == null) continue;

                    // Add pricing information for each passenger type
                    // (For example 2 adults are one pricing info)
                    var tempPricing = new Pricing();
                    var tempFares = new List<Fare>();
                    var tempTaxes = new List<Tax>();

                    var passengerCount = (int)(passengersCount[i]);

                    // Add passengers depending on passenger type
                    switch (i)
                    {
                        case (int)PassengerHelper.PassengerEnum.Adult:
                            tempPricing.Passengers =
                                new Model.QPX.Response.TripOptionModels.Passengers(passengerCount, 0, 0, 0, 0);
                            break;
                        case (int)PassengerHelper.PassengerEnum.Child:
                            tempPricing.Passengers =
                                new Model.QPX.Response.TripOptionModels.Passengers(0, passengerCount, 0, 0, 0);
                            break;
                        case (int)PassengerHelper.PassengerEnum.InfantInLap:
                            tempPricing.Passengers =
                                new Model.QPX.Response.TripOptionModels.Passengers(0, 0, passengerCount, 0, 0);
                            break;
                        case (int)PassengerHelper.PassengerEnum.InfantInSeat:
                            tempPricing.Passengers =
                                new Model.QPX.Response.TripOptionModels.Passengers(0, 0, 0, passengerCount, 0);
                            break;
                        case (int)PassengerHelper.PassengerEnum.Senior:
                            tempPricing.Passengers =
                                new Model.QPX.Response.TripOptionModels.Passengers(0, 0, 0, 0, passengerCount);
                            break;
                    }

                    decimal saleTaxTotal = 0;
                    decimal saleFareTotal = 0;
                    foreach (var slice in solution.InDirectFlights)
                    {
                        // For each flight in one slice
                        foreach (var flight in slice.Flights)
                        {
                            // Add fare depending on flight
                            tempFares.Add(FareHelper.CreateFareFrom(flight));

                            // For each flight add all corresponding taxes depending on flight route
                            foreach (var routeTax in routeTaxRepository.GetRouteTaxes(flight))
                            {
                                tempTaxes.Add(RouteTaxConverter.ToTripTax(routeTax, flight));
                                saleTaxTotal += TaxHelper.GetPrice(flight, routeTax.Tax);
                            }
                        }
                        saleFareTotal = slice.TotalBasePrice;
                    }

                    // Add fares
                    tempPricing.Fare = tempFares;

                    // Add taxes
                    tempPricing.Tax = tempTaxes;

                    // Add price informations
                    tempPricing.SaleFareTotal = PriceHelper.CreatePrice(saleFareTotal);
                    tempPricing.SaleTaxTotal = PriceHelper.CreatePrice(saleTaxTotal);
                    tempPricing.SaleTotal = PriceHelper.CreatePrice(saleFareTotal + saleTaxTotal);
                    tempPricings.Add(tempPricing);
                }

                // Add pricings to response
                response.Trips.TripOption[tripOptionIndex].Pricing = tempPricings;
                tripOptionIndex++;
            }
        }
    }
}
