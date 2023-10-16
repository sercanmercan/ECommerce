using ECommerce.Domain.Order;
using ECommerce.Domain.Product;
using ECommerce.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public Order CreateOrder(Order order)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Orders.Add(order);
                userDbContext.SaveChanges();
                return order;
            }
        }

        public void DeleteOrder(Guid id)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                var deleteProduct = GetOrderById(id);
                deleteProduct.IsDeleted = true;
                deleteProduct.DeletionTime = DateTime.Now;
                userDbContext.Orders.Update(deleteProduct);
                userDbContext.SaveChanges();
            }
        }

        public List<Order> GetAllOrder()
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Orders.ToList();
        }

        public Order? GetOrderById(Guid id)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Orders.Find(id);
        }

        public Order UpdateOrder(Order order)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Orders.Update(order);
                userDbContext.SaveChanges();
                return order;
            }
        }
        /// <summary>
        /// Geçmişteki tüm siparişleri getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Order>? GetOrderByUserId(Guid userId)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Orders.Where(x => x.UserId == userId).ToList();
        }
    }
}
