using Microsoft.EntityFrameworkCore;
using MovieAPI.Core;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{

    public class MovieDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public MovieDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            if (_movieContext.Database != null)
                _movieContext.Database.EnsureCreated();
        }

        public Movie GetEntity(long Id)
        {
            return _movieContext.Movies.FirstOrDefault(M => M.Id == Id);
        }

        public IEnumerable<Movie> RetrieveMovies(string title = null, string rating = null, string releaseYear = null)
        {
            IEnumerable<Movie> movies = _movieContext.Movies;

            if (movies == null)
                movies = new List<Movie>();

            if (!String.IsNullOrEmpty(title))
                movies = this.ApplySearchAlgorhythm(movies, title);

            if (!String.IsNullOrEmpty(rating))
                movies = movies.Where(m => m.AverageRating == rating);

            if (!String.IsNullOrEmpty(releaseYear))
                movies = movies.Where(m => m.ReleaseYear.ToString() == releaseYear);


            return movies;
        }

        public IEnumerable<Movie> ApplySearchAlgorhythm(IEnumerable<Movie> movies, String title)
        {
            // here we could use advanced searching algorhythms
            return movies.Where(M => M.Title.Contains(title));
        }
    }
}
