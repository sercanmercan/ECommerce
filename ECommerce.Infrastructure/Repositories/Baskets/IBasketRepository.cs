using ECommerce.Domain.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Baskets
{
    public interface IBasketRepository
    {
        List<Basket> CreateBasket(List<Basket> basket);
        List<Basket>? GetBasketByUserId(Guid userId);
        void DeleteProductInBasket(Guid userId, Guid productId, Guid id, bool isActive);
    }
}
