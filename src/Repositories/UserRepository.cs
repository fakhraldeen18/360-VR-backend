using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _users;
        private DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _users = databaseContext.Users;
            _databaseContext = databaseContext;
        }

        public User CreateOne(User user)
        {
            _users.Add(user);
            _databaseContext.SaveChanges();
            return user;
        }

        public User? DeleteOne(Guid userId)
        {
            User? deleteUser = FindOne(userId);
            _users.Remove(deleteUser!);
            _databaseContext.SaveChanges();
            return deleteUser;
        }

        public IEnumerable<User> FindAll(int limit, int offset)
        {
            if (limit == 0 & offset == 0)
            {
                return _users;
            }
            return _users.Skip(offset).Take(limit);

        }

        public User? FindOne(Guid userId)
        {
            User? findUser = _users.Find(userId);
            return findUser;    
        }

        public User UpdateOne(User updatedUser)
        {
            _users.Update(updatedUser);
            _databaseContext.SaveChanges();
            return updatedUser;
        }
    }
}