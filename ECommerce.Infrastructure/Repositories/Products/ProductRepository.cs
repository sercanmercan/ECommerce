using ECommerce.Domain.Product;
using ECommerce.Domain.User;
using ECommerce.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Products.Add(product);
                userDbContext.SaveChanges();
                return product;
            }
        }

        public void DeleteProduct(Guid id)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                var deleteProduct = GetProductsById(id);
                deleteProduct.IsDeleted = true;
                deleteProduct.DeletionTime = DateTime.Now;
                userDbContext.Products.Update(deleteProduct);
                userDbContext.SaveChanges();
            }
        }

        public List<Product> GetAllProduct()
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Products.ToList();
        }

        public Product? GetProductsById(Guid id)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Products.Find(id);
        }

        public Product UpdateProduct(Product product)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Products.Update(product);
                userDbContext.SaveChanges();
                return product;
            }
        }
    }
}
