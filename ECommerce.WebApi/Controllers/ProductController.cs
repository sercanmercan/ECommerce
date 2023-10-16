using ECommerce.Application.Interfaces.Products;
using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Application.Services.Products.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<bool> CreateProduct([FromBody] CreateProductRequestDto product)
        {
            return await _productAppService.CreateProductAsync(product);
        }

        [Route("api/[controller]/{id}")]
        [HttpPut]
        public async Task<bool> UpdateProduct(Guid id, [FromBody] CreateProductRequestDto product)
        {
            return await _productAppService.UpdateProductAsync(id, product);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<bool> DeleteProduct(Guid id)
        {
            return await _productAppService.DeleteProductAsync(id);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<ProductResponseDto>> GetAllProduct()
        {
            return await _productAppService.GetAllProductAsync();
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public async Task<ProductResponseDto> GetProductById(Guid id)
        {
            return await _productAppService.GetProductByIdAsync(id);
        }

        [Route("api/[controller]/total-price-for-all-product")]
        [HttpGet]
        public async Task<TotalPriceForAllProductResponseDto> GetTotalPriceForAllProduct(TotalPriceForAllProductRequestDto request)
        {
            return _productAppService.TotalPriceForAllProduct(request);
        }
    }
}
