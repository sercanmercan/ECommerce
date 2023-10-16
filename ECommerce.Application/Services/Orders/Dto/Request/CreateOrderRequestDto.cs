using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Orders.Dto.Request
{
    public class CreateOrderRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string? Note { get; set; }
        public string FullAddress { get; set; }

        public bool IsCheckValid()
        {
            if (ProductId == Guid.Empty ||
                UserId == Guid.Empty ||
                Quantity == 0 ||
                TotalPrice == 0 ||
                string.IsNullOrWhiteSpace(FullAddress))
                return false;
            return true;
        }
    }
}
