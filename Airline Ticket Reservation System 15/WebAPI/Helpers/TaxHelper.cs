using WebAPI.Models.FlightsDb;

namespace WebAPI.Helpers
{
    public static class TaxHelper
    {
        public static int GetUkDutyTaxId(Route route)
        {
            int distance = route.Distance;
            int brandA = 2000;
            int brandB = 4000;
            int brandC = 6000;

            if (distance < brandA)
            {
                return 1;
            }
            if (distance >= brandA && distance < brandB)
            {
                return 2;
            }
            if (distance >= brandB && distance < brandC)
            {
                return 3;
            }
            return 4;
        }

        public static decimal GetPrice(Flight flight, Tax tax)
        {
            if (tax.Price != 0)
                return tax.Price;

            return flight.BasePrice*(tax.Percentage/100);
        }
    }
}
