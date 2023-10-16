using ECommerce.Application.Services.Users.Dto;

namespace ECommerce.Application.Interfaces.Users
{
    public interface IUserAppService
    {
        Task<bool> CreateUserAsync(CreateUpdateUserRequestDto request);
        Task<bool> LoginAsync(LoginRequestDto request);
    }
}
