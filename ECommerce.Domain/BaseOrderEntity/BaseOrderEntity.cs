using ECommerce.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.BaseOrderEntity
{
    public class BaseOrderEntity : BaseEntity<Guid>
    {
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User.User Users { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Product.Product Product { get; set; }
    }
}
