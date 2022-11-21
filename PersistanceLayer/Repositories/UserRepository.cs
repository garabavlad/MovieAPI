using Microsoft.EntityFrameworkCore;
using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MovieDatabaseContext context) : base(context) {}

    public new IEnumerable<User> GetAll()
    {
        return _context.Users.Include(m => m.Reviews);
    }
}
