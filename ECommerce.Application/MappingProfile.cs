using AutoMapper;
using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Application.Services.Products.Dto.Response;
using ECommerce.Application.Services.Users.Dto;
using ECommerce.Domain.Product;
using ECommerce.Domain.User;

namespace ECommerce.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUpdateUserRequestDto, User>();
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
