using ECommerce.Domain.BaseEntity;
using ECommerce.Domain.BaseOrderEntity;
using ECommerce.Domain.Basket;
using ECommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Order
{
    public class Order : BaseOrderEntity.BaseOrderEntity
    {
        public string FullAddres { get; set; }
        public bool IsDelivery { get; set; }
        public OrderStatusesEnum OrderStatusId { get; set; }
        public ICollection<OrderHistory> OrderHistory { get; set; }

        //[ForeignKey("UserId")]
        //public Guid UserId { get; set; }
        //public User.User Users { get; set; }
        //[ForeignKey("ProductId")]
        //public Guid ProductId { get; set; }
        //public Product.Product Product { get; set; }
        //public string? Note { get; set; }
        //public double TotalPrice { get; set; }
        //public int Quantity { get; set; }
        //public string Description { get; set; }
    }
}