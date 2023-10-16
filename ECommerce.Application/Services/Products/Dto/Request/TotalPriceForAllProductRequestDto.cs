namespace ECommerce.Application.Services.Products.Dto.Request
{
    public class TotalPriceForAllProductRequestDto
    {
        public Dictionary<Guid, int> Products { get; set; }

        public bool IsCheckValid()
        {
            if (Products is null || Products.Count == 0)
                return false;

            return true;
        }
    }
}
