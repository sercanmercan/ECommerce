using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enums
{
    public enum OrderStatusesEnum
    {
        [Description("sepette")]
        InBasket = 1,

        [Description("hazırlanıyor")]
        Preparing = 2,

        [Description("kargoda")]
        InCargo = 3,

        [Description("teslimat dağıtımda")]
        InDistribution = 4,

        [Description("teslim edildi")]
        Delivered = 5,

        [Description("sipariş oluşturuldu")]
        CreatedOrder = 6
    }
}
