using ECommerce.Domain.BaseEntity;
using ECommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Product
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        [ForeignKey("ProductCategoryId")]
        public int ProductCategoryId { get; set; }
        public ProductCategoriesEnum ProductCategory { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        //[ForeignKey("StockId")]
        //public Guid? StockId { get; set; }
        //public Stock.Stock? Stock { get; set; }
    }
}
