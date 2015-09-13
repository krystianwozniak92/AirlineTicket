using WebAPI.Models.FlightsDb;

namespace WebAPI.Helpers
{
    public static class RouteTaxHelper
    {
        public static string GetFullTaxName(RouteTax routeTax)
        {
            string name = null;

            switch (routeTax.TaxID)
            {
                case 1:
                    name = routeTax.Tax.Name;
                    break;
                case 2:
                    name = routeTax.Tax.Name;
                    break;
                case 3:
                    name = routeTax.Tax.Name;
                    break;
                case 4:
                    name = routeTax.Tax.Name;
                    break;
                case 5:
                    name = string.Format("{0} {1}",
                        routeTax.Route.DepartureAirport.City.Country.Name, routeTax.Tax.Name);
                    break;
                case 6:
                    name = string.Format("{0} {1}",
                        routeTax.Route.DepartureAirport.City.Country.Name, routeTax.Tax.Name);
                    break;
                case 7:
                    break;
            }

            return name;
        }
        public static string GetFullTaxName(Models.FlightsDb.Country country, Tax tax)
        {
            string name = null;

            switch (tax.TaxID)
            {
                case 1:
                    name = tax.Name;
                    break;
                case 2:
                    name = tax.Name;
                    break;
                case 3:
                    name = tax.Name;
                    break;
                case 4:
                    name = tax.Name;
                    break;
                case 5:
                    name = string.Format("{0} {1}", country.Name, tax.Name);
                    break;
                case 6:
                    name = string.Format("{0} {1}", country.Name, tax.Name);
                    break;
                case 7:
                    break;
            }

            return name;
        }
    }
}
