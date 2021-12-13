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
    public class ReviewDO : BaseDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public ReviewDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public IEnumerable<ReviewModel> RetrieveReviewsByMovieId(long parentId)
        {
            IEnumerable<ReviewModel> reviews = _movieContext.Reviews;

            reviews = reviews.Where(x => x.ParentMovieId == parentId).ToList();
            return reviews;
        }

        public IEnumerable<ReviewModel> RetrieveReviewsByUserId(long parentId)
        {
            IEnumerable<ReviewModel> reviews = _movieContext.Reviews;

            reviews = reviews.Where(x => x.ParentUserId == parentId).ToList();
            return reviews;
        }

        public void AddOrUpdateEntity(ReviewModel reviewModel)
        {
            ReviewModel existingReview = _movieContext.Reviews.FirstOrDefault(R => R.ParentMovieId == reviewModel.ParentMovieId && R.ParentUserId == reviewModel.ParentUserId);

            if (existingReview == null)
            {
                // it's a new review
                _movieContext.Reviews.Add(reviewModel);
                _movieContext.SaveChanges();
            }
            else
            {
                // it's updating review
                existingReview.Rating = reviewModel.Rating;
                _movieContext.Entry(existingReview).State = EntityState.Modified;
                _movieContext.SaveChanges();
            }
        }

    }
}
