using AutoMapper;
using AutoMapper.Internal.Mappers;
using ECommerce.Application.Interfaces.Users;
using ECommerce.Application.Services.Users.Dto;
using ECommerce.Domain.User;
using ECommerce.Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _usersRepository;
        public UserAppService(IMapper mapper,
            IUserRepository usersRepository) 
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }
        
        /// <summary>
        /// Kullanıcı kaydını yapar.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> CreateUserAsync(CreateUpdateUserRequestDto request)
        {
            string resultError = string.Empty;

            try
            {
                if (!request.IsValid())
                {
                    resultError = "Lütfen bilgileri giriniz.";
                    throw new ArgumentException(resultError);
                }

                User map = _mapper.Map<CreateUpdateUserRequestDto, User>(request);
                //parolayı hashleyip kayıt edilmesi gerekiyor.
                bool isValidEmail = _usersRepository.ControlUserByEmail(map.Email);

                if(isValidEmail)
                {
                    resultError = "Bu email zaten kayıtlıdır. Başka bir email ile oluşturunuz.";
                    throw new ArgumentException(resultError);
                }

                if(map is not null)
                {
                    map.IsActive = true;
                    _usersRepository.CreateUser(map);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

        /// <summary>
        /// Kullanıcı girişini yapar.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> LoginAsync(LoginRequestDto request)
        {
            string resultError = string.Empty;

            try
            {
                User? user = _usersRepository.GetUserByEmail(request.Email);

                if (user is null)
                {
                    resultError = "Bu email ile kayıt yoktur.";
                    throw new ArgumentException(resultError);
                }

                if(user.Password != request.Password)
                {
                    resultError = "Lütfen parolayı kontrol ediniz.";
                    throw new ArgumentException(resultError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultError) ? resultError : "Bir hata olustu");
            }
        }

    }
}
