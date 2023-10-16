using ECommerce.Domain.Order;
using ECommerce.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Orders
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        void DeleteOrder(Guid id);
        List<Order> GetAllOrder();
        Order? GetOrderById(Guid id);
        Order UpdateOrder(Order order);
        List<Order>? GetOrderByUserId(Guid userId);
    }
}
