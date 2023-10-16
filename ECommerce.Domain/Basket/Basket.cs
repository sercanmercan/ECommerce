using ECommerce.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Basket
{
    public class Basket : BaseOrderEntity.BaseOrderEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
