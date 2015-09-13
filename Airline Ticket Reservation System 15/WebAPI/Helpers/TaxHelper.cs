using WebAPI.Models.FlightsDb;

namespace WebAPI.Helpers
{
    public static class TaxHelper
    {
        public static int GetUKDutyTaxID(Route route)
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
    }
}
