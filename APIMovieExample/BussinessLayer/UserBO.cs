using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.DataLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.BussinessLayer
{
    public class UserBO : BaseBO
    {
        private UserModel _contextEntity;
        private DbContext _context;
        public UserBO(DbContext context)
        {
            _context = context;
        }

        public void SetEntityContext(UserModel contextEntity)
        {
            _contextEntity = contextEntity;
        }

        public UserModel GetEntityContext()
        {
            return _contextEntity;
        }

        public UserModel GetEntity(long Id)
        {
            UserDO userDO = new UserDO(_context);
            return userDO.GetEntity(Id);
        }

        public UserModel SearchForUser(String username)
        {
            UserDO userDO = new UserDO(_context);
            return userDO.GetEntity(username);
        }

        public IEnumerable<MovieModel> GetTop5MoviesByRating()
        {
            ReviewBO reviewBO = new ReviewBO(_context);
            MovieBO movieBO = new MovieBO(_context);

            // Retrieving the top 5 review movies
            List<ReviewModel> reviews = reviewBO.SearchForReviewsByUserParent(_contextEntity.Id).OrderByDescending(R => R.Rating).Take(5).ToList();
            List<MovieModel> movies = new List<MovieModel>();

            reviews.ForEach(R => movies.Add(movieBO.GetEntity(R.ParentMovieId))); // Adding each movie model to the list for each of the top 5 reviews

            return movies.OrderBy(M => M.Title);
        }
    }
}
