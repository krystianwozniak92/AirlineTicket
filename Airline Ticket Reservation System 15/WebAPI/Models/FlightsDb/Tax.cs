using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.FlightsDb
{
    public class Tax : IEquatable<Tax>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Percentage { get; set; }
        public string Code { get; set; }

        public int ChargeTypeID { get; set; }
        public virtual ChargeType ChargeType { get; set; }
        public virtual ICollection<RouteTax> RouteTaxes { get; set; }

        public bool Equals(Tax other)
        {
            return Code == other.Code;
        }
    }
}
