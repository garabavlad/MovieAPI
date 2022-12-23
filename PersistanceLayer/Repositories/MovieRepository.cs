using Microsoft.EntityFrameworkCore;
using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDatabaseContext context) : base(context)
    {
    }

    public new IEnumerable<Movie> GetAll()
    {
        return _context.Movies.Include(m => m.Reviews).Include(m => m.GenreMovie);
    }
}
