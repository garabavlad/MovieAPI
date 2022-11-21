using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(MovieDatabaseContext context) : base(context)
    {
    }

}
