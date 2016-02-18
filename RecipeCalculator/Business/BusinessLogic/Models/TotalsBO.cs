using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using Common;

namespace BusinessLogic.Models
{
    public class TotalsBO
    {
        public decimal TaxSum { get; set; }
        public decimal DiscountSum { get; set; }
        public decimal TotalSum { get; set; }
    }
}
