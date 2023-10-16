using AutoMapper;
using ECommerce.Application.Interfaces.Orders;
using ECommerce.Application.Services.Orders.Dto.Request;
using ECommerce.Application.Services.Orders.Dto.Response;
using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Application.Services.Products.Dto.Response;
using ECommerce.Domain.Order;
using ECommerce.Domain.Product;
using ECommerce.Infrastructure.Repositories.Orders;
using ECommerce.Infrastructure.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public OrderAppService(IMapper mapper,
            IOrderRepository orderRepository) {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(CreateOrderRequestDto request)
        {
            string resultError = string.Empty;
            try
            {
                if (!request.IsCheckValid())
                {
                    resultError = "Lütfen bilgileri doğru giriniz.";
                    throw new ArgumentException(resultError);
                }

                Order map = _mapper.Map<CreateOrderRequestDto, Order>(request);

                _orderRepository.CreateOrder(map);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<List<OrderResponseDto>> GetAllOrderByUserIdAsync(Guid userId)
        {
            List<Order>? orderList = _orderRepository.GetOrderByUserId(userId);
            List<OrderResponseDto> map = _mapper.Map<List<Order>?, List<OrderResponseDto>>(orderList);
            return map;
        }
    }
}
