using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Meal : IComparer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MealID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public int Compare(object x, object y)
        {
            Meal a = (Meal)x;
            Meal b = (Meal)y;

            if (a.MealID < b.MealID)
                return 1;
            if (a.MealID == b.MealID)
                return 0;
            else
                return -1;
        }
    }
}
