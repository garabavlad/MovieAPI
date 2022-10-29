using APIMovieExample.DataLayer;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class ReviewBO
{
    private DbContext _context;
    public ReviewBO(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<Review> SearchForReviewsByMovieParent(long parentId)
    {
        ReviewDO reviewDO = new ReviewDO(_context);
        IEnumerable<Review> reviews = reviewDO.RetrieveReviewsByMovieId(parentId);

        return reviews;
    }

    public IEnumerable<Review> SearchForReviewsByUserParent(long parentId)
    {
        ReviewDO reviewDO = new ReviewDO(_context);
        IEnumerable<Review> reviews = reviewDO.RetrieveReviewsByUserId(parentId);

        return reviews;
    }

    public void InsertReview(User user, Movie movie, int rating)
    {
        ReviewDO reviewDO = new ReviewDO(_context);
        var newReview = new Review
        {
            Rating = rating.ToString(),
            ParentMovie = movie,
            ParentMovieId = movie.Id,
            ParentUser = user,
            ParentUserId = user.Id
        };

        reviewDO.AddOrUpdateEntity(newReview);
    }
}
