using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BusinessLogic.Models
{
    public class ProductBO
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public Enums.ProductTypes ProductType { get; set; }
        public Enums.UnitTypes UnitType { get; set; }
        public decimal Price { get; set; }
        public bool IsOrganic { get; set; }
    }
}
