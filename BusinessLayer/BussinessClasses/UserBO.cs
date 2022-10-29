using APIMovieExample.DataLayer;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class UserBO
{
    private User _contextEntity;
    private DbContext _context;
    public UserBO(DbContext context)
    {
        _context = context;
    }

    public void SetEntityContext(User contextEntity)
    {
        _contextEntity = contextEntity;
    }

    public User GetEntityContext()
    {
        return _contextEntity;
    }

    public User GetEntity(long Id)
    {
        UserDO userDO = new UserDO(_context);
        return userDO.GetEntity(Id);
    }

    public User SearchForUser(String username)
    {
        UserDO userDO = new UserDO(_context);
        return userDO.GetEntity(username);
    }

    public IEnumerable<Movie> GetTop5MoviesByRating()
    {
        ReviewBO reviewBO = new ReviewBO(_context);
        MovieBO movieBO = new MovieBO(_context);

        // Retrieving the top 5 review movies
        List<Review> reviews = reviewBO.SearchForReviewsByUserParent(_contextEntity.Id).OrderByDescending(R => R.Rating).Take(5).ToList();
        List<Movie> movies = new List<Movie>();

        reviews.ForEach(R => movies.Add(movieBO.GetEntity(R.ParentMovieId))); // Adding each movie model to the list for each of the top 5 reviews

        return movies.OrderBy(M => M.Title);
    }
}
