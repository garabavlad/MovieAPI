namespace MovieAPI.Models;

public class MovieGenre
{
    public MovieGenre() { }

    public long Id { get; set; }
    public long ParentMovieId { get; set; }
    public Movie Movie { get; set; }
    public long ParentGenreId { get; set; }
    public Genre Genre { get; set; }

}
