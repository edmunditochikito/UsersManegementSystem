using UsersManegementSystem.Data.Repository.IRepository;
using UsersManegementSystem.Models;

namespace UsersManegementSystem.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(User user)
        {
            var objFromDb = _db.User.FirstOrDefault(s => s.Id == user.Id);
            objFromDb.Name = user.Name;
            objFromDb.Email = user.Email;
            objFromDb.Phone = user.Phone;
            objFromDb.Role = user.Role;
            _db.SaveChanges();

        }
    }
}
