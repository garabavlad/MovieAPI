using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{
    public class UserDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public UserDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public User GetEntity(String username)
        {
            return _movieContext.Users.FirstOrDefault(U => U.Username.ToLower() == username.ToLower());
        }

        public User GetEntity(long Id)
        {
            return _movieContext.Users.FirstOrDefault(U => U.Id == Id);
        }

    }
}
