using ECommerce.Application.Services.Orders.Dto.Request;
using ECommerce.Application.Services.Orders.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Orders
{
    public interface IOrderAppService
    {
        Task<bool> CreateOrderAsync(CreateOrderRequestDto request);

        /// <summary>
        /// Tüm siparişleri getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<OrderResponseDto>> GetAllOrderByUserIdAsync(Guid userId);
    }
}
