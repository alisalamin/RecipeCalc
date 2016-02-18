using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using Common;

namespace BusinessLogic.Models
{
    public class ReceiptItemBO
    {
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public Enums.UnitTypes UnitType { get; set; }
        public long ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.ProductTypes ProductType { get; set; }
        public decimal WellnessDiscount { get; set; }
        public decimal ItemTax { get; set; }
        public decimal BeforeTaxTotal { get; set; }
        public decimal ItemTotal { get; set; }
    }
}
