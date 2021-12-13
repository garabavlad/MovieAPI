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
    public class ReviewBO : BaseBO
    {
        private DbContext _context;
        public ReviewBO(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<ReviewModel> SearchForReviewsByMovieParent(long parentId)
        {
            ReviewDO reviewDO = new ReviewDO(_context);
            IEnumerable<ReviewModel> reviews = reviewDO.RetrieveReviewsByMovieId(parentId);

            return reviews;
        }

        public IEnumerable<ReviewModel> SearchForReviewsByUserParent(long parentId)
        {
            ReviewDO reviewDO = new ReviewDO(_context);
            IEnumerable<ReviewModel> reviews = reviewDO.RetrieveReviewsByUserId(parentId);

            return reviews;
        }

        public void InsertReview(UserModel user, MovieModel movie, int rating)
        {
            ReviewDO reviewDO = new ReviewDO(_context);
            var newReview = new ReviewModel();
            newReview.Rating = rating.ToString();
            newReview.ParentMovie = movie;
            newReview.ParentMovieId = movie.Id;
            newReview.ParentUser = user;
            newReview.ParentUserId = user.Id;

            reviewDO.AddOrUpdateEntity(newReview);
        }
    }
}
