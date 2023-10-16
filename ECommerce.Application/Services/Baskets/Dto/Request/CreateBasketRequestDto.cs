using ECommerce.Domain.Product;
using ECommerce.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Baskets.Dto.Request
{
    public class CreateBasketRequestDto
    {
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        //public bool IsCheckValid()
        //{
        //    if (ProductId == Guid.Empty ||
        //        UserId == Guid.Empty ||
        //        Quantity == 0 ||
        //        TotalPrice == 0 ||
        //        string.IsNullOrWhiteSpace(Description))
        //        return false;
        //    return true;
        //}
    }
}
