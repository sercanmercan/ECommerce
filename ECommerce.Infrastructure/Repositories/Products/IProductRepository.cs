using ECommerce.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Products
{
    public interface IProductRepository
    {
        Product CreateProduct(Product product);
        void DeleteProduct(Guid id);
        List<Product> GetAllProduct();
        Product? GetProductsById(Guid id);
        Product UpdateProduct(Product product);
    }
}
