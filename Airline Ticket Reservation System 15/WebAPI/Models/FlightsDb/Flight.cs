using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightID { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime Date { get; set; }
        public int SeatCountLeft { get; set; }
        public string Code { get; set; }

        public int AircraftID { get; set; }
        public int RouteID { get; set; }
        public int MealID { get; set; }

        public virtual Aircraft Aircraft { get; set; }
        public virtual Route Route { get; set; }
        public virtual Meal Meal { get; set; }

        
    }
}
