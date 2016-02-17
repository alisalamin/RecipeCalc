using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public interface IRateAdjustment : IEntity<int>
    {
        decimal SalesTax { get; set; }
        decimal WellnessDiscountRate { get; set; }
    }

    public class RateAdjustment : IRateAdjustment
    {
        [Key, Required]
        public int Id { get; set; }
        public decimal SalesTax { get; set; }
        public decimal WellnessDiscountRate { get; set; }

        [ForeignKey("ApplicationConfig")]
        public Guid AppId { get; set; }
        public ApplicationConfig ApplicationConfig { get; set; }
    }
}
