using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Models.Interfaces;

namespace WebAPI.Models
{
    public class Solution
    {
        public ICollection<IInDirectFlight> InDirectFlights { get; set; }

        public decimal TotalBasePrice
        {
            get
            {
                return InDirectFlights.Sum(inDirectFlight => inDirectFlight.TotalBasePrice);
            }
        }

        public Solution()
        {
            InDirectFlights = new List<IInDirectFlight>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var inDirectFlight in InDirectFlights)
                builder.Append("InDirectFlight:\n" + inDirectFlight + "\n");

            return string.Format("Solution\n" + builder.ToString());
        }
    }
}
