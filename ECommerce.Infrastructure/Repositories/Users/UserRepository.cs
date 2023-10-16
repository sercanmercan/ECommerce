using ECommerce.Domain.User;
using ECommerce.Infrastructure.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                var deleteUser = GetUsersById(id);
                deleteUser.IsDeleted = true;
                deleteUser.DeletionTime = DateTime.Now;
                userDbContext.Users.Update(deleteUser);
                userDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Users.ToList();
        }

        public User? GetUsersById(int id)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                userDbContext.Users.Update(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public bool ControlUserByEmail(string email)
        {
            using (var userDbContext = new ECommerceDbContext())
                return userDbContext.Users.Any(x=>x.Email == email);
        }

        public User? GetUserByEmail(string email)
        {
            using (var userDbContext = new ECommerceDbContext())
            {
                User? user = userDbContext.Users.Where(x=>x.Email == email).FirstOrDefault();
                return user;
            }
        }
    }
}
