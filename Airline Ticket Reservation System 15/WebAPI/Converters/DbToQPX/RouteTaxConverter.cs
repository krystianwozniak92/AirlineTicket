using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Helpers;
using WebAPI.Models.FlightsDb;
using Tax = Model.QPX.Response.TripOptionModels.Tax;

namespace WebAPI.Converters.DbToQPX
{
    public static class RouteTaxConverter
    {
        public static Tax ToTripTax(RouteTax routeTax, Flight flight)
        {
            var tax = new Tax();

            tax.ID = routeTax.IdNumber;
            tax.ChangeType = routeTax.Tax.ChargeType.Name;
            tax.Code = routeTax.Tax.Code;
            tax.Country = routeTax.Route.DepartureAirport.City.Country.ISOCode;
            tax.SalePrice = PriceHelper.CreatePrice(TaxHelper.GetPrice(flight, routeTax.Tax));

            return tax;
        }


    }
}