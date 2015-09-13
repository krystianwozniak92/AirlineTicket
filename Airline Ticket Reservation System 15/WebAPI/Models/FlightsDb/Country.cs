using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Carrier> Carriers { get; set; }
    }
}
