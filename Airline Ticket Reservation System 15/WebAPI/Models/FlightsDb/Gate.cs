using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Gate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GateID { get; set; }
        public string Name { get; set; }

        public int TerminalID { get; set; }

        public virtual Terminal Terminal { get; set; }
    }
}
