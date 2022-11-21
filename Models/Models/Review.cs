using System.Text.Json.Serialization;

namespace MovieAPI.Models;

public class Review
{
    private decimal _rating;

    public Review() { }

    public Review(decimal rating, Movie parentMovie, User parentUser)
    {
        if (parentMovie == null)
            throw new NotSupportedException("Review Constructor cannot have a null movie parent");
        if (parentUser == null)
            throw new NotSupportedException("Review Constructor cannot have a null user parent");

        _rating = rating;
        User = parentUser;
        Movie = parentMovie;
        ParentMovieId = parentMovie.Id;
        ParentUserId = parentUser.Id;
    }

    public long Id { get; set; }

    public long ParentMovieId { get; set; }
    public Movie Movie { get; set; } // parent

    public long ParentUserId { get; set; }
    public User User { get; set; } // parent

    public decimal Rating
    {
        get 
        {
            //return Algorhythms.GetReviewRating(_rating);
            return _rating;
        }
        set
        {
            _rating = value;
        }
    }
}
