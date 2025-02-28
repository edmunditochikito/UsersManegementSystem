using UsersManegementSystem.Models;

namespace UsersManegementSystem.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {

        void update(User user);
    }
}
