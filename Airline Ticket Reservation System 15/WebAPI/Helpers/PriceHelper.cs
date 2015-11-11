using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Helpers
{
    public static class PriceHelper
    {
        public static string CreatePrice(decimal value)
        {
            var price = value.ToString("##.###");
            if(price.Length >= 6)
                Debug.WriteLine("Price: {0} from value: {1}", price, value);
            return string.Format("{0}{1}", "PLN", price);
        }

    }
}