using ECommerce.Domain.BaseEntity;

namespace ECommerce.Domain.User
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
