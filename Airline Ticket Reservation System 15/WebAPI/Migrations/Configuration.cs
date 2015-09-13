using System.Collections.Generic;
using WebAPI.DAL;
using WebAPI.Helpers;
using WebAPI.Models.FlightsDb;
using WebAPI.Repository;
using WebAPI.Repository.Interfaces;
using Country = WebAPI.Models.FlightsDb.Country;

namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI.DAL.FlightsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPI.DAL.FlightsContext context)
        {

            AddCountries(context);

            AddCities(context);

            AddAirports(context);

            AddCabins(context);

            AddMeals(context);

            AddChargeTypes(context);

            AddTaxes(context);

            AddCarriers(context);

            AddAircrafts(context);

            AddRoutes(context);

            AddRouteTaxs(context);

            //int year = 2015;
            //int startMonth = 9;
            //int endMonth = 9;
            //int startDay = 1;
            //int endDay = 2;
            //AddRandomFlights(context, year, startMonth, endMonth, startDay, endDay);

            AddFixedFlights(context);
        }

        private void AddRandomFlights(FlightsContext context, int year, int startMonth, int endMonth,
            int startDay, int endDay)
        {
            // Fill database with  large random flight list for a specific year
            const int carriers = 5;
            int globalFlightId = 1;
            int routesCount = context.Routes.Count();
            int mealsCount = context.Meals.Count();
            var routes = context.Routes.Local;

            Random generator = new Random();

            for (int month = startMonth; month <= endMonth; month++)
            {
                for (int day = startDay; day <= endDay; day++)
                {
                    for (int carrierId = 1; carrierId < carriers; carrierId++)
                    {
                        var flights = new List<Flight>();

                        for (int flightID = 1 + month + day + carrierId - 3; flightID < routesCount; flightID++)
                        {
                            int randomPrice = generator.Next(routes[flightID - 1].Duration,
                                3*routes[flightID - 1].Duration);

                            DateTime dateTime = new DateTime(year, month, day, generator.Next(6, 20),
                                generator.Next(0, 59), 0);

                            // int routeID = flightID - month - day - carrierID + 3;
                            int routeID = generator.Next(1, routesCount + 1);

                            var tempFlight = new Flight
                            {
                                FlightID = globalFlightId++,
                                BasePrice = randomPrice,
                                Date = dateTime,
                                SeatCountLeft = 180,
                                AircraftID = carrierId,
                                RouteID = routeID,
                                MealID = generator.Next(1, mealsCount),
                                Code = generator.Next(100, 999).ToString()
                            };

                            flights.Add(tempFlight);
                        }

                        //Console.WriteLine("Month: [{0}], Day: [{1}], Carrier: [{2}], Time: [{3}]",
                        //    month, day, carrierId, DateTime.Now.ToShortTimeString());

                        context.Flights.AddOrUpdate(f => f.FlightID, flights.ToArray());
                        context.SaveChanges();
                    }
                }
            }
        }

        private void AddFixedFlights(FlightsContext context)
        {
            // Fill database with static flights 
            DateTime fixDateTime = new DateTime(2015, 9, 1, 12, 0, 0);
            var flights = new List<Flight>
            {
                // WRO - BER 10:00 - 19:00 EACH HOUR
                new Flight {FlightID = 11, BasePrice = 50, Date = fixDateTime.AddHours(-2), RouteID = 169, SeatCountLeft = 180, Code = "011", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 12, BasePrice = 60, Date = fixDateTime.AddHours(-1), RouteID = 169, SeatCountLeft = 180, Code = "012", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 13, BasePrice = 70, Date = fixDateTime.AddHours(0), RouteID = 169, SeatCountLeft = 180, Code = "013", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 14, BasePrice = 80, Date = fixDateTime.AddHours(1), RouteID = 169, SeatCountLeft = 180, Code = "014", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 15, BasePrice = 90, Date = fixDateTime.AddHours(2), RouteID = 169, SeatCountLeft = 180, Code = "015", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 16, BasePrice = 100, Date = fixDateTime.AddHours(3), RouteID = 169, SeatCountLeft = 180, Code = "016", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 17, BasePrice = 110, Date = fixDateTime.AddHours(4), RouteID = 169, SeatCountLeft = 180, Code = "017", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 18, BasePrice = 120, Date = fixDateTime.AddHours(5), RouteID = 169, SeatCountLeft = 180, Code = "018", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 19, BasePrice = 130, Date = fixDateTime.AddHours(6), RouteID = 169, SeatCountLeft = 180, Code = "019", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 20, BasePrice = 140, Date = fixDateTime.AddHours(7), RouteID = 169, SeatCountLeft = 180, Code = "020", AircraftID = 1,  MealID = 1},

                // BER - ALC 10:00 - 19:00 EACH HOUR
                new Flight {FlightID = 21, BasePrice = 10, Date = fixDateTime.AddHours(-2), RouteID = 527, SeatCountLeft = 180, Code = "021", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 22, BasePrice = 20, Date = fixDateTime.AddHours(-1), RouteID = 527, SeatCountLeft = 180, Code = "022", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 23, BasePrice = 30, Date = fixDateTime.AddHours(0), RouteID = 527, SeatCountLeft = 180, Code = "023", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 24, BasePrice = 40, Date = fixDateTime.AddHours(1), RouteID = 527, SeatCountLeft = 180, Code = "024", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 25, BasePrice = 50, Date = fixDateTime.AddHours(2), RouteID = 527, SeatCountLeft = 180, Code = "025", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 26, BasePrice = 60, Date = fixDateTime.AddHours(3), RouteID = 527, SeatCountLeft = 180, Code = "026", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 27, BasePrice = 70, Date = fixDateTime.AddHours(4), RouteID = 527, SeatCountLeft = 180, Code = "027", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 28, BasePrice = 80, Date = fixDateTime.AddHours(5), RouteID = 527, SeatCountLeft = 180, Code = "028", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 29, BasePrice = 90, Date = fixDateTime.AddHours(6), RouteID = 527, SeatCountLeft = 180, Code = "029", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 30, BasePrice = 100, Date = fixDateTime.AddHours(7), RouteID = 527, SeatCountLeft = 180, Code = "030", AircraftID = 1,  MealID = 1},

                // ALC - WRO 10:00 - 19:00 EACH HOUR
                new Flight {FlightID = 41, BasePrice = 100, Date = fixDateTime.AddHours(-2), RouteID = 785, SeatCountLeft = 180, Code = "041", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 42, BasePrice = 120, Date = fixDateTime.AddHours(-1), RouteID = 785, SeatCountLeft = 180, Code = "042", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 43, BasePrice = 130, Date = fixDateTime.AddHours(0), RouteID = 785, SeatCountLeft = 180, Code = "043", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 44, BasePrice = 140, Date = fixDateTime.AddHours(1), RouteID = 785, SeatCountLeft = 180, Code = "044", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 45, BasePrice = 150, Date = fixDateTime.AddHours(2), RouteID = 785, SeatCountLeft = 180, Code = "045", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 46, BasePrice = 160, Date = fixDateTime.AddHours(3), RouteID = 785, SeatCountLeft = 180, Code = "046", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 47, BasePrice = 170, Date = fixDateTime.AddHours(4), RouteID = 785, SeatCountLeft = 180, Code = "047", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 48, BasePrice = 180, Date = fixDateTime.AddHours(5), RouteID = 785, SeatCountLeft = 180, Code = "048", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 49, BasePrice = 190, Date = fixDateTime.AddHours(6), RouteID = 785, SeatCountLeft = 180, Code = "049", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 40, BasePrice = 200, Date = fixDateTime.AddHours(7), RouteID = 785, SeatCountLeft = 180, Code = "050", AircraftID = 1,  MealID = 1},

                // ALC - BER 10:00 - 19:00 EACH HOUR
                new Flight {FlightID = 51, BasePrice = 50, Date = fixDateTime.AddHours(-2), RouteID = 794, SeatCountLeft = 180, Code = "041", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 52, BasePrice = 50, Date = fixDateTime.AddHours(-1), RouteID = 794, SeatCountLeft = 180, Code = "042", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 53, BasePrice = 50, Date = fixDateTime.AddHours(0), RouteID = 794, SeatCountLeft = 180, Code = "043", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 54, BasePrice = 60, Date = fixDateTime.AddHours(1), RouteID = 794, SeatCountLeft = 180, Code = "044", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 55, BasePrice = 60, Date = fixDateTime.AddHours(2), RouteID = 794, SeatCountLeft = 180, Code = "045", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 56, BasePrice = 60, Date = fixDateTime.AddHours(3), RouteID = 794, SeatCountLeft = 180, Code = "046", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 57, BasePrice = 70, Date = fixDateTime.AddHours(4), RouteID = 794, SeatCountLeft = 180, Code = "047", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 58, BasePrice = 70, Date = fixDateTime.AddHours(5), RouteID = 794, SeatCountLeft = 180, Code = "048", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 59, BasePrice = 70, Date = fixDateTime.AddHours(6), RouteID = 794, SeatCountLeft = 180, Code = "049", AircraftID = 1,  MealID = 1},
                new Flight {FlightID = 60, BasePrice = 80, Date = fixDateTime.AddHours(7), RouteID = 794, SeatCountLeft = 180, Code = "050", AircraftID = 1,  MealID = 1},
            };
            
            context.Flights.AddOrUpdate(f => f.FlightID, flights.ToArray());
            context.SaveChanges();
        }

        private void AddRouteTaxs(FlightsContext context)
        {
            var routeTaxs = new List<RouteTax>();
            var taxRepository = new TaxRepository();

            int routeTaxIdCounter = 1;

            // For each route add the appropriate taxes for it
            foreach (var route in context.Routes)
            {
                RouteTax tempRouteTax;

                ///// Add GOVERNMENT TAXES AND FEES
                // Add UK Air Passenger Duty
                // if route origin it's located in UK
                if (route.DepartureAirport.City.CountryID ==
                    CountryHelper.GetCountryID(Helpers.Country.UnitedKingdom))
                {
                    tempRouteTax = new RouteTax
                    {
                        RouteTaxID = routeTaxIdCounter++,
                        RouteID = route.RouteID,
                        TaxID = TaxHelper.GetUKDutyTaxID(route),
                        IdNumber = routeTaxIdCounter.ToString(),
                        Name = RouteTaxHelper.GetFullTaxName(
                            RouteHelper.GetDepartureCountry(route),
                            taxRepository.GetById(TaxHelper.GetUKDutyTaxID(route)))
                    };

                    routeTaxs.Add(tempRouteTax);
                }

                // Add Airport Security Tax depending on route departure
                tempRouteTax = new RouteTax
                {
                    RouteTaxID = routeTaxIdCounter++,
                    RouteID = route.RouteID,
                    TaxID = 6,
                    Name = RouteTaxHelper.GetFullTaxName(
                        RouteHelper.GetDepartureCountry(route),
                        taxRepository.GetById(6))
                };

                routeTaxs.Add(tempRouteTax);
                // Add Passenger Service Charge depending on route departure


                ///// Add Carrier subcharges
                
                // Save changes
                context.RouteTaxes.AddOrUpdate(r => r.RouteTaxID, routeTaxs.ToArray());
                context.SaveChanges();
            }
        }

        private void AddRoutes(FlightsContext context)
        {


            // Create all possible routes for all airports
            var generator = new Random();
            var routes = new List<Route>();
            var airports = context.Airports.Local;

            for (int id = 1, constId = 1; id < airports.Count*(airports.Count - 1) + 1; id++)
            {
                int departureId = (int) (Math.Floor(((double) id/airports.Count)) + 1);
                int destinationId = id%airports.Count + 1;
                int departureCountryId = (int) (Math.Floor(((double) (departureId - 1)/(airports.Count/4)))) + 1;
                int destinationCountryId = (int) (Math.Floor(((double) (destinationId - 1)/(airports.Count/4)))) + 1;

                int distanceBorders = departureCountryId - destinationCountryId;
                if (distanceBorders < 0)
                    distanceBorders *= -1;

                int distance = generator.Next(700*distanceBorders + 200, 700*distanceBorders + 500);
                int duration = (distance/650)*60 + generator.Next(50, 70);

                if (departureId != destinationId)
                {
                    var tempRoute = new Route
                    {
                        RouteID = constId,
                        DepartureAirportID = departureId,
                        DestinationAirportID = destinationId,
                        Distance = distance,
                        Duration = duration
                    };
                    routes.Add(tempRoute);
                    constId++;
                }
            }
            context.Routes.AddOrUpdate(c => c.RouteID, routes.ToArray());
            context.SaveChanges();
        }

        private void AddAircrafts(FlightsContext context)
        {
            var aircrafts = new List<Aircraft>
            {
                new Aircraft {AircraftID = 1, Name = "Airbus A320", Code = "320", CabinID = 1, CarrierID = 1},
                new Aircraft {AircraftID = 2, Name = "Airbus A320", Code = "320", CabinID = 1, CarrierID = 2},
                new Aircraft {AircraftID = 3, Name = "Airbus A320", Code = "320", CabinID = 1, CarrierID = 3},
                new Aircraft {AircraftID = 4, Name = "Airbus A320", Code = "320", CabinID = 1, CarrierID = 4},
                new Aircraft {AircraftID = 5, Name = "Airbus A320", Code = "320", CabinID = 1, CarrierID = 5},
                new Aircraft {AircraftID = 6, Name = "Airbus A330", Code = "332", CabinID = 1, CarrierID = 1},
                new Aircraft {AircraftID = 7, Name = "Airbus A330", Code = "332", CabinID = 1, CarrierID = 2},
                new Aircraft {AircraftID = 8, Name = "Airbus A330", Code = "332", CabinID = 1, CarrierID = 3},
                new Aircraft {AircraftID = 9, Name = "Airbus A330", Code = "332", CabinID = 1, CarrierID = 4},
                new Aircraft {AircraftID = 10, Name = "Airbus A330", Code = "332", CabinID = 1, CarrierID = 5},
                new Aircraft {AircraftID = 11, Name = "Boeing 737", Code = "738", CabinID = 1, CarrierID = 1},
                new Aircraft {AircraftID = 12, Name = "Boeing 737", Code = "738", CabinID = 1, CarrierID = 2},
                new Aircraft {AircraftID = 13, Name = "Boeing 737", Code = "738", CabinID = 1, CarrierID = 3},
                new Aircraft {AircraftID = 14, Name = "Boeing 737", Code = "738", CabinID = 1, CarrierID = 4},
                new Aircraft {AircraftID = 15, Name = "Boeing 737", Code = "738", CabinID = 1, CarrierID = 5}
            };
            aircrafts.ForEach(c => context.Aircrafts.AddOrUpdate(e => e.AircraftID, c));
            context.SaveChanges();
        }

        private void AddCarriers(FlightsContext context)
        {
            var carriers = new List<Carrier>
            {
                new Carrier {CarrierID = 1, Name = "LOT - Polish Airlines", Code = "LO", CountryID = 1},
                new Carrier {CarrierID = 2, Name = "Air Berlin", Code = "AB", CountryID = 2},
                new Carrier {CarrierID = 3, Name = "Deutsche Lufthansa AG", Code = "LH", CountryID = 2},
                new Carrier {CarrierID = 4, Name = "Air France", Code = "AF", CountryID = 3},
                new Carrier {CarrierID = 5, Name = "Ryanair", Code = "FR", CountryID = 6}
            };
            carriers.ForEach(c => context.Carriers.AddOrUpdate(e => e.CarrierID, c));
            context.SaveChanges();
        }

        private void AddTaxes(FlightsContext context)
        {
            var taxes = new List<Tax>
            {
                new Tax
                {
                    TaxID = 1,
                    Price = new decimal(13.00),
                    Name = "UK Air Passenger Duty",
                    Code = "PDA_A",
                    ChargeTypeID = 1
                },
                new Tax
                {
                    TaxID = 2,
                    Price = new decimal(67.00),
                    Name = "UK Air Passenger Duty",
                    Code = "PDA_B",
                    ChargeTypeID = 1
                },
                new Tax
                {
                    TaxID = 3,
                    Price = new decimal(83.00),
                    Name = "UK Air Passenger Duty",
                    Code = "PDA_C",
                    ChargeTypeID = 1
                },
                new Tax
                {
                    TaxID = 4,
                    Price = new decimal(94.00),
                    Name = "UK Air Passenger Duty",
                    Code = "PDA_D",
                    ChargeTypeID = 1
                },
                new Tax
                {
                    TaxID = 5,
                    Price = 0,
                    Percentage = new decimal(10),
                    Name = "Passenger Service Charge",
                    Code = "RD",
                    ChargeTypeID = 1
                },
                new Tax
                {
                    TaxID = 6,
                    Price = 0,
                    Percentage = new decimal(12),
                    Name = "Airport Security tax",
                    Code = "AT",
                    ChargeTypeID = 1
                },
            };
            taxes.ForEach(c => context.Taxes.AddOrUpdate(e => e.TaxID, c));
            context.SaveChanges();
        }

        private static void AddChargeTypes(FlightsContext context)
        {
            var chargeTypes = new List<ChargeType>
            {
                new ChargeType {ChargeTypeID = 1, Name = "GOVERNMENT"},
                new ChargeType {ChargeTypeID = 2, Name = "CARRIER_SURCHARGE"}
            };
            chargeTypes.ForEach(c => context.ChargeTypes.AddOrUpdate(e => e.ChargeTypeID, c));
            context.SaveChanges();
        }

        private void AddMeals(FlightsContext context)
        {
            var meals = new List<Meal>
            {
                new Meal {MealID = 1, Name = "Food and Beverages for Purchase"},
                new Meal {MealID = 2, Name = "Meal"},
                new Meal {MealID = 3, Name = "Snack or Brunch"}
            };
            meals.ForEach(c => context.Meals.AddOrUpdate(e => e.MealID, c));
            context.SaveChanges();
        }

        private void AddCabins(FlightsContext context)
        {
            var cabins = new List<Cabin>
            {
                new Cabin {CabinID = 1, Name = "COACH"},
                new Cabin {CabinID = 2, Name = "PREMIUM COACH"},
                new Cabin {CabinID = 3, Name = "BUSINESS"},
                new Cabin {CabinID = 4, Name = "FIRST CLASS"}
            };
            context.Cabins.AddOrUpdate(cabin => cabin.CabinID, cabins.ToArray());
            context.SaveChanges();
        }

        private void AddAirports(FlightsContext context)
        {
            var airports = new List<Airport>
            {
                // Polish Airports
                new Airport {AirportID = 1, Name = "Gdañsk Lech Wa³êsa Airport", IATA = "GDN", CityID = 1},
                new Airport {AirportID = 2, Name = "Solidarity Szczecin-Goleniów Airport", IATA = "SZZ", CityID = 2},
                new Airport {AirportID = 3, Name = "Poznañ–£awica Henryk Wieniawski Airport", IATA = "POZ", CityID = 3},
                new Airport {AirportID = 4, Name = "Warsaw-Chopin Airport", IATA = "WAW", CityID = 4},
                new Airport {AirportID = 5, Name = "Wroc³aw-Copernicus Airport", IATA = "WRO", CityID = 5},
                new Airport {AirportID = 6, Name = "John Paul II International Airport Kraków–Balice", IATA = "KRK", CityID = 6},
                new Airport {AirportID = 7, Name = "Katowice International Airport", IATA = "KTW", CityID = 7},
                new Airport {AirportID = 8, Name = "Rzeszów-Jasionka Airport", IATA = "RZE", CityID = 8},
                new Airport {AirportID = 9, Name = "Lublin Airport", IATA = "LUZ", CityID = 9},
                new Airport {AirportID = 10, Name = "Bydgoszcz Ignacy Jan Paderewski Airport", IATA = "LUZ", CityID = 10},

                // Germany Airports
                new Airport {AirportID = 11, Name = "Dortmund Airport", IATA = "DTM", CityID = 11},
                new Airport {AirportID = 12, Name = "Hamburg Airport", IATA = "HAM", CityID = 12},
                new Airport {AirportID = 13, Name = "Hannover-Langenhagen Airport", IATA = "HAJ", CityID = 13},
                new Airport {AirportID = 14, Name = "Berlin Brandenburg Airport", IATA = "BER", CityID = 14},
                new Airport {AirportID = 15, Name = "Cologne Bonn Airport", IATA = "CGN", CityID = 15},
                new Airport {AirportID = 16, Name = "Nuremberg Airport", IATA = "NUE", CityID = 16},
                new Airport {AirportID = 17, Name = "Stuttgart Airport", IATA = "STR", CityID = 17},
                new Airport {AirportID = 18, Name = "Frankfurt Airport", IATA = "FRA", CityID = 18},
                new Airport {AirportID = 19, Name = "Leipzig/Halle Airport", IATA = "LEJ", CityID = 19},
                new Airport {AirportID = 20, Name = "Munich Airport", IATA = "MUC", CityID = 20},

                // Spanish Airports
                new Airport {AirportID = 21, Name = "Alicante Airport", IATA = "ALC", CityID = 21},
                new Airport {AirportID = 22, Name = "Almería Airport", IATA = "LEI", CityID = 22},
                new Airport {AirportID = 23, Name = "El Prat / Barcelona Airport", IATA = "BCN", CityID = 23},
                new Airport {AirportID = 24, Name = "Bilbao Airport", IATA = "BIO", CityID = 24},
                new Airport {AirportID = 25, Name = "Girona–Costa Brava Airport", IATA = "GRO", CityID = 25},
                new Airport {AirportID = 26, Name = "Madrid Barajas International Airport", IATA = "MAD", CityID = 26},
                new Airport {AirportID = 27, Name = "MAlaga Airport", IATA = "AGP", CityID = 27},
                new Airport {AirportID = 28, Name = "Murcia-San Javier Airport", IATA = "MJV", CityID = 28},
                new Airport {AirportID = 29, Name = "Valencia Airport", IATA = "VLC", CityID = 29},
                new Airport {AirportID = 30, Name = "Zaragoza Airport", IATA = "ZAZ", CityID = 30},

                // British Airports
                new Airport {AirportID = 31, Name = "Birmingham Airport", IATA = "BHX", CityID = 31},
                new Airport {AirportID = 32, Name = "Bournemouth Airport", IATA = "BOH", CityID = 32},
                new Airport {AirportID = 33, Name = "Bristol Airport", IATA = "BRS", CityID = 33},
                new Airport {AirportID = 34, Name = "Cardiff Airport", IATA = "CWL", CityID = 34},
                new Airport {AirportID = 35, Name = "Glasgow International Airport", IATA = "GGW", CityID = 35},
                new Airport {AirportID = 36, Name = "Liverpool-John Lennon Airport", IATA = "LPL", CityID = 36},
                new Airport {AirportID = 37, Name = "London Heathrow Airport", IATA = "LHR", CityID = 37},
                new Airport {AirportID = 38, Name = "Leeds/Bradford Airport", IATA = "LBA", CityID = 38},
                new Airport {AirportID = 39, Name = "Manchester Airport", IATA = "MAN", CityID = 39},
                new Airport {AirportID = 40, Name = "Newcastle International Airport", IATA = "NCL", CityID = 40},
            };
            context.Airports.AddOrUpdate(airport => airport.AirportID, airports.ToArray());
            context.SaveChanges();
        }

        private void AddCities(FlightsContext context)
        {
            var cities = new List<City>
            {
                // Polish cities
                new City {CityID = 1, Name = "Gdansk", IATA = "GDN", CountryID = 1},
                new City {CityID = 2, Name = "Szczecin", IATA = "SZZ", CountryID = 1},
                new City {CityID = 3, Name = "Poznan", IATA = "POZ", CountryID = 1},
                new City {CityID = 4, Name = "Warsaw", IATA = "WAW", CountryID = 1},
                new City {CityID = 5, Name = "Wroclaw", IATA = "WRO", CountryID = 1},
                new City {CityID = 6, Name = "Krakow", IATA = "KRK", CountryID = 1},
                new City {CityID = 7, Name = "Katowice", IATA = "KTW", CountryID = 1},
                new City {CityID = 8, Name = "Rzeszow", IATA = "RZE", CountryID = 1},
                new City {CityID = 9, Name = "Lublin", IATA = "LUZ", CountryID = 1},
                new City {CityID = 10, Name = "Bydgoszcz", IATA = "BZG", CountryID = 1},

                // German cities
                new City {CityID = 11, Name = "Dortmund", IATA = "DTM", CountryID = 2},
                new City {CityID = 12, Name = "Hamburg", IATA = "HAM", CountryID = 2},
                new City {CityID = 13, Name = "Hanower", IATA = "HAJ", CountryID = 2},
                new City {CityID = 14, Name = "Berlin", IATA = "BER", CountryID = 2},
                new City {CityID = 15, Name = "Drezno", IATA = "DRS", CountryID = 2},
                new City {CityID = 16, Name = "Norymberga", IATA = "NUE", CountryID = 2},
                new City {CityID = 17, Name = "Stuttgard", IATA = "STR", CountryID = 2},
                new City {CityID = 18, Name = "Frankfurt", IATA = "FRA", CountryID = 2},
                new City {CityID = 19, Name = "Lipsk", IATA = "LEJ", CountryID = 2},
                new City {CityID = 20, Name = "Monachium", IATA = "MUC", CountryID = 2},

                // Spanish cities
                new City {CityID = 21, Name = "Alicante", IATA = "ALC", CountryID = 5},
                new City {CityID = 22, Name = "Almeria", IATA = "LEI", CountryID = 5},
                new City {CityID = 23, Name = "Barcelona", IATA = "BCN", CountryID = 5},
                new City {CityID = 24, Name = "Bilbao", IATA = "BIO", CountryID = 5},
                new City {CityID = 25, Name = "Girona", IATA = "GRO", CountryID = 5},
                new City {CityID = 26, Name = "Madrid", IATA = "MAD", CountryID = 5},
                new City {CityID = 27, Name = "Malaga", IATA = "AGP", CountryID = 5},
                new City {CityID = 28, Name = "Murcia", IATA = "MJV", CountryID = 5},
                new City {CityID = 29, Name = "Valencia", IATA = "VLC", CountryID = 5},
                new City {CityID = 30, Name = "Zaragoza", IATA = "ZAZ", CountryID = 5},

                // British cities
                new City {CityID = 31, Name = "Birmingham", IATA = "BHX", CountryID = 4},
                new City {CityID = 32, Name = "Bournemouth", IATA = "BOH", CountryID = 4},
                new City {CityID = 33, Name = "Bristol", IATA = "BRS", CountryID = 4},
                new City {CityID = 34, Name = "Cardiff", IATA = "CWL", CountryID = 4},
                new City {CityID = 35, Name = "Glasgow", IATA = "GGW", CountryID = 4},
                new City {CityID = 36, Name = "Liverpool", IATA = "LPL", CountryID = 4},
                new City {CityID = 37, Name = "London", IATA = "LHR", CountryID = 4},
                new City {CityID = 38, Name = "Leeds Bradford", IATA = "LBA", CountryID = 4},
                new City {CityID = 39, Name = "Manchester", IATA = "MAN", CountryID = 4},
                new City {CityID = 40, Name = "Newcastle", IATA = "NCL", CountryID = 4},
            };
            context.Cities.AddOrUpdate(city => city.CityID, cities.ToArray());
            context.SaveChanges();
        }

        private void AddCountries(FlightsContext context)
        {
            var countries = new List<Country>
            {
                new Country {CountryID = 1, Name = "Poland", ISOCode = "PL"},
                new Country {CountryID = 2, Name = "Germany", ISOCode = "DE"},
                new Country {CountryID = 3, Name = "France", ISOCode = "FR"},
                new Country {CountryID = 4, Name = "United Kingdom", ISOCode = "GB"},
                new Country {CountryID = 5, Name = "Spain", ISOCode = "ES"},
                new Country {CountryID = 6, Name = "Ireland", ISOCode = "IE"}
            };
            context.Countries.AddOrUpdate(country => country.CountryID, countries.ToArray());
            context.SaveChanges();
        }

    }
}
