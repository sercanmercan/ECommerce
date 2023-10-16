using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Products.Dto.Request
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductCategoriesEnum ProductCategoryId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }

        public bool IsCheckValid()
        {
            if(string.IsNullOrWhiteSpace(Name) || Price == 0.0 || ProductCategoryId == 0 || Quantity == 0)
                return false;
            return true;
        }
    }
}
