using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.DataLayer
{

    public class MovieDO : BaseDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public MovieDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            if (_movieContext.Database != null)
                _movieContext.Database.EnsureCreated();
        }

        public MovieModel GetEntity(long Id)
        {
            return _movieContext.Movies.FirstOrDefault(M => M.Id == Id);
        }

        public IEnumerable<MovieModel> RetrieveMovies(string title = null, string rating = null, string releaseYear = null)
        {
            IEnumerable<MovieModel> movies = _movieContext.Movies;

            if (movies == null)
                movies = new List<MovieModel>();

            if (!String.IsNullOrEmpty(title))
                movies = Algorhythms.ApplySearchAlgorhythm(movies, title);

            if (!String.IsNullOrEmpty(rating))
                movies = movies.Where(m => m.AverageRating == rating);

            if (!String.IsNullOrEmpty(releaseYear))
                movies = movies.Where(m => m.ReleaseYear.ToString() == releaseYear);


            return movies;
        }


    }
}
