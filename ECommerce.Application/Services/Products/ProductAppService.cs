using AutoMapper;
using ECommerce.Application.Interfaces.Products;
using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Application.Services.Products.Dto.Response;
using ECommerce.Domain.Product;
using ECommerce.Infrastructure.Repositories.Products;
using ECommerce.Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductAppService(IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public TotalPriceForAllProductResponseDto TotalPriceForAllProduct(TotalPriceForAllProductRequestDto request)
        {
            string resultError = string.Empty;

            try
            {
                if (request.IsCheckValid())
                {
                    resultError = "Lütfen ürün seçiniz.";
                    throw new ArgumentException(resultError);
                }

                double totalPrice = 0;
                TotalPriceForAllProductResponseDto totalPriceForAllProductResponseDto = new();

                foreach (var item in request.Products)
                {
                    double? price = _productRepository.GetProductsById(item.Key)?.Price;

                    if (price is not null)
                        totalPrice += (price.Value * item.Value);
                }

                totalPriceForAllProductResponseDto.TotalPrice = totalPrice;
                return totalPriceForAllProductResponseDto;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<bool> CreateProductAsync(CreateProductRequestDto request)
        {
            string resultError = string.Empty;

            try
            {
                if (!request.IsCheckValid())
                {
                    resultError = "Lütfen bilgileri giriniz.";
                    throw new ArgumentException(resultError);
                }

                Product map = _mapper.Map<CreateProductRequestDto, Product>(request);

                _productRepository.CreateProduct(map);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<bool> UpdateProductAsync(Guid id, CreateProductRequestDto request)
        {
            string resultError = string.Empty;

            try
            {
                if (!request.IsCheckValid())
                {
                    resultError = "Lütfen bilgileri giriniz.";
                    throw new ArgumentException(resultError);
                }

                Product? product = _productRepository.GetProductsById(id);

                if (product is null)
                {
                    resultError = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultError);
                }

                product.ProductCategoryId = (int)request.ProductCategoryId;
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                _productRepository.UpdateProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            string resultError = string.Empty;

            try
            {
                Product? product = _productRepository.GetProductsById(id);

                if (product is null)
                {
                    resultError = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultError);
                }

                product.IsDeleted = true;
                product.DeletionTime = DateTime.Now;
                _productRepository.UpdateProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        public async Task<List<ProductResponseDto>> GetAllProductAsync()
        {
            List<Product> productList = _productRepository.GetAllProduct();
            List<ProductResponseDto> map = _mapper.Map<List<Product>, List<ProductResponseDto>>(productList);
             return map;
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(Guid id)
        {
            Product? product = _productRepository.GetProductsById(id);
            ProductResponseDto map = _mapper.Map<Product?, ProductResponseDto>(product);
            return map;
        }
    }
}
