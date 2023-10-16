using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Baskets.Dto.Response
{
    public class BasketResponseDto
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
