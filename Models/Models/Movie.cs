namespace MovieAPI.Models;

public class Movie
{
    public long Id { get; set; }
    public String Title { get; set; }
    public IEnumerable<MovieGenre> GenreMovie { get; set; }
    public IEnumerable<Review> Reviews { get; set; }

    public Movie()
    {
        Title = String.Empty;
        GenreMovie = new List<MovieGenre>();
        Reviews = new List<Review>();
    }

    public Movie(string name, List<MovieGenre> genres, List<Review> reviews)
    {
        Title = name;
        GenreMovie = genres;
        Reviews = reviews;
    }
}
