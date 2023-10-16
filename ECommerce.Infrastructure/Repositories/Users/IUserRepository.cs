using ECommerce.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User? GetUsersById(int id);
        User UpdateUser(User user);
        bool ControlUserByEmail(string email);
        User? GetUserByEmail(string email);
    }
}
