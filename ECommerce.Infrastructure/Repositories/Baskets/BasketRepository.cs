using ECommerce.Domain.Basket;
using ECommerce.Infrastructure.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Baskets
{
    public class BasketRepository : IBasketRepository
    {
        /// <summary>
        /// Sepetin içine ekleme yapar.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public List<Basket> CreateBasket(List<Basket> basket)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                foreach (var item in basket)
                {
                    userDbContext.Baskets.Add(item);
                    userDbContext.SaveChanges();
                }
                
                return basket;
            }
        }

        /// <summary>
        /// Kullanıcı id sine göre sepetteki siparişleri getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Basket>? GetBasketByUserId(Guid userId)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Baskets.Where(x => x.UserId == userId && x.IsActive).ToList();
        }

        /// <summary>
        /// Sepetin içindeki ürünü çıkartmak için kullanılır.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="isActive"></param>
        public void DeleteProductInBasket(Guid userId, Guid productId, Guid id, bool isActive)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                Basket? basket = userDbContext.Baskets.Where(x => x.UserId == userId &&
                x.IsActive &&
                x.ProductId == productId &&
                x.Id == id).FirstOrDefault();

                basket.IsDeleted = true;
                userDbContext.Baskets.Update(basket);
                userDbContext.SaveChanges();
            }
                
        }
    }
}
