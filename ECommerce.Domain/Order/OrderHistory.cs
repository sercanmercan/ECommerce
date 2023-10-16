using ECommerce.Domain.BaseEntity;
using ECommerce.Domain.Enums;
using ECommerce.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Order
{
    public class OrderHistory : BaseEntity<Guid>
    {
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatusesEnum StatusId { get; set; }
    }
}
