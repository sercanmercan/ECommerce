using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Application.Services.Products.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Products
{
    public interface IProductAppService
    {
        TotalPriceForAllProductResponseDto TotalPriceForAllProduct(TotalPriceForAllProductRequestDto request);
        Task<bool> CreateProductAsync(CreateProductRequestDto request);
        Task<bool> UpdateProductAsync(Guid id, CreateProductRequestDto request);
        Task<bool> DeleteProductAsync(Guid id);
        Task<List<ProductResponseDto>> GetAllProductAsync();
        Task<ProductResponseDto> GetProductByIdAsync(Guid id);
    }
}
