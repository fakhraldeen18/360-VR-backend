using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository()
        {
            _users = new DatabasesContext().Users;
        }

        public User CreateOne(User user)
        {
            _users.Add(user);
            return user;
        }

        public List<User> DeleteOne(string userId)
        {
            var deleteUser = _users.Find((user) => user.Id == userId);
            if (deleteUser == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                _users.Remove(deleteUser);
                return _users;
            }
        }

        public List<User> FindAll()
        {
            return _users;
        }

        public User? FindOne(string userId)
        {
            var FindUser = _users.Find((user) => user.Id == userId);
            return FindUser;
        }

    }
}