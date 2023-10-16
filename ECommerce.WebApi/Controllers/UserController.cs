using ECommerce.Application.Interfaces.Users;
using ECommerce.Application.Services.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<bool> CreateUser([FromBody] CreateUpdateUserRequestDto user)
        {
            return await _userAppService.CreateUserAsync(user);
        }

        [Route("api/[controller]/login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<bool> LoginUser([FromBody] LoginRequestDto request)
        {
            return await _userAppService.LoginAsync(request);
        }
    }
}
