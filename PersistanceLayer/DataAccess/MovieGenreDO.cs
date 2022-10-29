using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{
    public class MovieGenreDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public MovieGenreDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public IEnumerable<MovieGenre> RetrieveMovieGenres(long parentId)
        {
            IEnumerable<MovieGenre> genres = _movieContext.MovieGenres;

            genres = genres.Where(x => x.ParentMovieId == parentId).ToList();


            return genres;
        }

    }
}
