using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace DataAccess.Models
{
    public enum ProductTypes
    {
        None = 0,
        Produce = 1,
        Meat = 2,
        Pantry = 3
    }

    public interface IProduct : IEntity<long>
    {
        string ProductName { get; set; }
        ProductTypes ProductType { get; set; }
        Enums.UnitTypes UnitType { get; set; }
        decimal Price { get; set; }
        bool IsOrganic { get; set; }
    }

    public class Product : IProduct
    {
        [Key, Required]
        public long Id { get; set; }
        [StringLength(200), Required]
        public string ProductName { get; set; }
        [Required]
        public ProductTypes ProductType { get; set; }
        [Required]
        public Enums.UnitTypes UnitType { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsOrganic { get; set; }
    }
}
