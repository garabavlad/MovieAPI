using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class MovieGenreRepository : GenericRepository<MovieGenre>, IMovieGenreRepository
{
    public MovieGenreRepository(MovieDatabaseContext context) : base(context)
    {
    }
}
