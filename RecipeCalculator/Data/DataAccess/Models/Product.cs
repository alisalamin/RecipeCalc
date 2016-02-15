using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DataAccess.Models
{
    public enum ProductTypes
    {
        None = 0,
        Produce = 1,
        Meat = 2,
        Pantry = 3
    }

    public interface IProduct : IEntity<int>
    {
        string ProductName { get; set; }
        ProductTypes ProductType { get; set; }
        decimal PricePerOunce { get; set; }
        decimal Price { get; set; }
        bool IsOrganic { get; set; }
    }

    public class Product : IProduct
    {
        [Key, Required]
        public int Id { get; set; }
        [StringLength(200), Required]
        public string ProductName { get; set; }
        [Required]
        public ProductTypes ProductType { get; set; }
        public decimal PricePerOunce { get; set; }
        public decimal Price { get; set; }
        public bool IsOrganic { get; set; }
    }
}
