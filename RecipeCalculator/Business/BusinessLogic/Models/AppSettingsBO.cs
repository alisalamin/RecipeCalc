using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Models
{
   public class AppSettingsBO
    {
        public Guid AppId { get; set; }

        public string AppName { get; set; }

        public decimal SalesTax { get; set; }

        public decimal WellnessDiscountRate { get; set; }
    }
}
