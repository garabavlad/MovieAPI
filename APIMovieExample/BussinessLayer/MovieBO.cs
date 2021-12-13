using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.DataLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.BussinessLayer
{
    public class MovieBO : BaseBO
    {
        private DbContext _context;
        public MovieBO(DbContext context)
        {
            _context = context;
        }

        public MovieModel GetEntity(long Id, Boolean getChildren = true)
        {
            ReviewBO reviewBO = new ReviewBO(_context);
            MovieGenreBO genresBO = new MovieGenreBO(_context);
            MovieDO movieDO = new MovieDO(_context);
            MovieModel movie = movieDO.GetEntity(Id);

            movie.Reviews = reviewBO.SearchForReviewsByMovieParent(movie.Id).ToList();
            movie._Genres = genresBO.SearchForGenres(movie.Id).ToList();

            return movie;
        }

        public IEnumerable<MovieModel> SearchForMovies(string title = null, string rating = null, string releaseYear = null, List<string> genres = null, Boolean loadChildren = true)
        {
            ReviewBO reviewBO = new ReviewBO(_context);
            MovieGenreBO genresBO = new MovieGenreBO(_context);
            MovieDO movieDO = new MovieDO(_context);
            IEnumerable<MovieModel> movies = movieDO.RetrieveMovies(title, rating, releaseYear);

            if (movies == null)
                throw new Exception();
            if (movies.Count() == 0)
                throw new Exception();

            // now retrieving the child classes for movie:
            if (loadChildren)
            {
                foreach(var movie in movies)
                {
                    movie.Reviews = reviewBO.SearchForReviewsByMovieParent(movie.Id).ToList();
                    movie._Genres = genresBO.SearchForGenres(movie.Id).ToList();
                }
            }

            if (genres != null)
                movies = Algorhythms.ApplyGenreFilter(movies, genres);

            return movies;
        }

        public IEnumerable<MovieModel> GetTop5MoviesByRating()
        {
            IEnumerable<MovieModel> movies = this.SearchForMovies(); // return all movies
            return movies.OrderByDescending(M => M.AverageRating).ThenBy(M => M.Title).Take(5);
        }
    }
}
