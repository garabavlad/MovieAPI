using APIMovieExample.DataLayer;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class MovieGenreBO
{
    private DbContext _context;
    public MovieGenreBO(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<MovieGenre> SearchForGenres(long parentId)
    {
        MovieGenreDO reviewDO = new MovieGenreDO(_context);
        IEnumerable<MovieGenre> genres = reviewDO.RetrieveMovieGenres(parentId);

        return genres;
    }

}
