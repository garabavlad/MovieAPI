using APIMovieExample.DataLayer;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Core;
using MovieAPI.Models;

namespace MovieAPI.Business;
public class MovieBO
{
    private DbContext _context;
    public MovieBO(DbContext context)
    {
        _context = context;
    }

    public Movie GetEntity(long Id)
    {
        ReviewBO reviewBO = new ReviewBO(_context);
        MovieGenreBO genresBO = new MovieGenreBO(_context);
        MovieDO movieDO = new MovieDO(_context);
        Movie movie = movieDO.GetEntity(Id);

        movie.Reviews = reviewBO.SearchForReviewsByMovieParent(movie.Id).ToList();
        movie._Genres = genresBO.SearchForGenres(movie.Id).ToList();

        return movie;
    }

    public IEnumerable<Movie> SearchForMovies(string title = null, string rating = null, string releaseYear = null, List<string> genres = null, Boolean loadChildren = true)
    {
        ReviewBO reviewBO = new ReviewBO(_context);
        MovieGenreBO genresBO = new MovieGenreBO(_context);
        MovieDO movieDO = new MovieDO(_context);
        IEnumerable<Movie> movies = movieDO.RetrieveMovies(title, rating, releaseYear);

        if (movies == null)
            throw new Exception();
        if (movies.Count() == 0)
            throw new Exception();

        // now retrieving the child classes for movie:
        if (loadChildren)
        {
            foreach (var movie in movies)
            {
                movie.Reviews = reviewBO.SearchForReviewsByMovieParent(movie.Id).ToList();
                movie._Genres = genresBO.SearchForGenres(movie.Id).ToList();
            }
        }

        if (genres != null)
            movies = this.ApplyGenreFilter(movies, genres);

        return movies;
    }

    public IEnumerable<Movie> GetTop5MoviesByRating()
    {
        IEnumerable<Movie> movies = this.SearchForMovies(); // return all movies
        return movies.OrderByDescending(M => M.AverageRating).ThenBy(M => M.Title).Take(5);
    }

    public IEnumerable<Movie> ApplyGenreFilter(IEnumerable<Movie> movies, List<String> genres)
    {
        // here should refubrish later with maybe a IEqualityComparer
        var tmpMovies = new List<Movie>();
        if (genres != null && genres.Count > 0)
        {
            foreach (var movie in movies)
            {
                foreach (var movieGenre in movie._Genres)
                {
                    foreach (var searchGenre in genres)
                    {
                        if (movieGenre.Name.ToLower() == searchGenre.ToLower()
                            && !tmpMovies.Contains(movie))
                        {
                            tmpMovies.Add(movie);
                        }
                    }
                }
            }
        }
        return tmpMovies;
    }
}
