using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class RateAdjustmentBO 
    {
        public int Id { get; set; }

        public decimal SalesTax { get; set; }

        public decimal WellnessDiscountRate { get; set; }
    }
}
