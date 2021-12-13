using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.DataLayer
{
    public class UserDO : BaseDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public UserDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public UserModel GetEntity(String username)
        {
            return _movieContext.Users.FirstOrDefault(U => U.Username.ToLower() == username.ToLower());
        }

        public UserModel GetEntity(long Id)
        {
            return _movieContext.Users.FirstOrDefault(U => U.Id == Id);
        }

    }
}
