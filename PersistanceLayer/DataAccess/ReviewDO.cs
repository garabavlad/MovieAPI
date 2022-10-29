using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{
    public class ReviewDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public ReviewDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public IEnumerable<Review> RetrieveReviewsByMovieId(long parentId)
        {
            IEnumerable<Review> reviews = _movieContext.Reviews;

            reviews = reviews.Where(x => x.ParentMovieId == parentId).ToList();
            return reviews;
        }

        public IEnumerable<Review> RetrieveReviewsByUserId(long parentId)
        {
            IEnumerable<Review> reviews = _movieContext.Reviews;

            reviews = reviews.Where(x => x.ParentUserId == parentId).ToList();
            return reviews;
        }

        public void AddOrUpdateEntity(Review reviewModel)
        {
            Review existingReview = _movieContext.Reviews.FirstOrDefault(R => R.ParentMovieId == reviewModel.ParentMovieId && R.ParentUserId == reviewModel.ParentUserId);

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
