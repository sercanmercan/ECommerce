using ECommerce.Application.Interfaces.Orders;
using ECommerce.Application.Services.Orders.Dto.Request;
using ECommerce.Application.Services.Orders.Dto.Response;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService) {
            _orderAppService = orderAppService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<bool> CreateOrder([FromBody] CreateOrderRequestDto order)
        {
            return await _orderAppService.CreateOrderAsync(order);
        }

        [HttpGet]
        [Route("api/[controller]/all-order-by-user-id")]
        public async Task<List<OrderResponseDto>> GetAllOrderByUserId(Guid userId)
        {
            return await _orderAppService.GetAllOrderByUserIdAsync(userId);
        }
    }
}
