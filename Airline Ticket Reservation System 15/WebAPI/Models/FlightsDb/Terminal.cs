using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Terminal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TerminalID { get; set; }
        public string Name { get; set; }

        public int AirportID { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual ICollection<Gate>  Gates { get; set; }


    }
}
