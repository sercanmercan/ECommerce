using ECommerce.Application.Interfaces.Baskets;
using ECommerce.Application.Interfaces.Products;
using ECommerce.Application.Services.Baskets.Dto.Request;
using ECommerce.Application.Services.Baskets.Dto.Response;
using ECommerce.Application.Services.Products.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketAppService _basketAppService;
        public BasketController(IBasketAppService basketAppService)
        {
            _basketAppService = basketAppService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<bool> CreateBasket([FromBody] List<CreateBasketRequestDto> product)
        {
            return await _basketAppService.CreateBasketAsync(product);
        }

        [Route("api/[controller]/basket-user-id")]
        [HttpGet]
        public async Task<List<BasketResponseDto>> GetBasketByUserId(Guid userId)
        {
            return await _basketAppService.GetBasketByUserIdAsync(userId);
        }

        [Route("api/[controller]/product-in-basket")]
        [HttpDelete]
        public async Task<bool> DeleteProductInBasket([FromBody] ProductInBasketRequestDto request)
        {
            return await _basketAppService.DeleteProductInBasketAsync(request);
        }
    }
}
