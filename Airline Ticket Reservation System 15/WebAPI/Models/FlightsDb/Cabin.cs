using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Cabin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CabinID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; } 
    }
}
