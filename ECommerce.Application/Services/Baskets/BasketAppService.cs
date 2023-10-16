using AutoMapper;
using Azure.Core;
using ECommerce.Application.Interfaces.Baskets;
using ECommerce.Application.Services.Baskets.Dto.Request;
using ECommerce.Application.Services.Baskets.Dto.Response;
using ECommerce.Application.Services.Orders.Dto.Request;
using ECommerce.Domain.Basket;
using ECommerce.Domain.Order;
using ECommerce.Infrastructure.Repositories.Baskets;
using ECommerce.Infrastructure.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Baskets
{
    public class BasketAppService : IBasketAppService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        public BasketAppService(IMapper mapper,
            IBasketRepository basketRepository) 
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        public async Task<bool> CreateBasketAsync(List<CreateBasketRequestDto> request)
        {
            string resultError = string.Empty;
            try
            {
                List<Basket> map = _mapper.Map<List<CreateBasketRequestDto>, List<Basket>>(request);
                _basketRepository.CreateBasket(map);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<List<BasketResponseDto>>? GetBasketByUserIdAsync(Guid userId)
        {
            string resultError = string.Empty;
            try
            {
                List<Basket>? basketList = _basketRepository.GetBasketByUserId(userId);
                List<BasketResponseDto> map = _mapper.Map<List<Basket>, List<BasketResponseDto>>(basketList);

                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<bool>? DeleteProductInBasketAsync(ProductInBasketRequestDto request)
        {
            string resultError = string.Empty;
            try
            {
                _basketRepository.DeleteProductInBasket(request.UserId, request.ProductId, request.Id, request.IsActive);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }
    }
}
