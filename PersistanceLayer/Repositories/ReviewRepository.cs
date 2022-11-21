using Microsoft.EntityFrameworkCore;
using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(MovieDatabaseContext context) : base(context)
    {
    }

    public new IEnumerable<Review> GetAll()
    {
        return _context.Reviews.Include(m => m.Movie).Include(m => m.User);
    }

    public void AddOrUpdateEntity(Review reviewModel)
    {
        Review existingReview = _context.Reviews.FirstOrDefault(R => R.ParentMovieId == reviewModel.ParentMovieId && R.ParentUserId == reviewModel.ParentUserId);

        if (existingReview == null)
        {
            // it's a new review
            _context.Reviews.Add(reviewModel);
            _context.SaveChanges();
        }
        else
        {
            // it's updating review
            existingReview.Rating = reviewModel.Rating;
            _context.Entry(existingReview).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
