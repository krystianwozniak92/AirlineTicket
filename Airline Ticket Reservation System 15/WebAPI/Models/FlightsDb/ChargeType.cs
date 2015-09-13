using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class ChargeType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChargeTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<Tax> Taxes { get; set; }
    }
}
