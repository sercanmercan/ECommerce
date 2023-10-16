using ECommerce.Application.Services.Products.Dto.Request;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Products.Dto.Response
{
    public class ProductResponseDto : CreateProductRequestDto
    {
        public Guid Id { get; set; }
    }
}
