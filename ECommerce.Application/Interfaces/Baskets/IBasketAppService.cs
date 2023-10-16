using ECommerce.Application.Services.Baskets.Dto.Request;
using ECommerce.Application.Services.Baskets.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Baskets
{
    public interface IBasketAppService
    {
        Task<bool> CreateBasketAsync(List<CreateBasketRequestDto> request);
        Task<List<BasketResponseDto>>? GetBasketByUserIdAsync(Guid userId);
        Task<bool>? DeleteProductInBasketAsync(ProductInBasketRequestDto request);
    }
}
