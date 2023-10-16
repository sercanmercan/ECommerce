using System.ComponentModel;

namespace ECommerce.Domain.Enums
{
    public enum ProductCategoriesEnum
    {
        [Description("Kadın")]
        Women = 1,

        [Description("Erkek")]
        Man = 2,

        [Description("Teknoloji")]
        Technology = 3,

        [Description("Gıda")]
        Food = 4
    }
}
