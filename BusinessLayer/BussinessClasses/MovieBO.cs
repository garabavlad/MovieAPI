using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Business;
public class MovieBO
{
    private IUnitOfWork _unitOfWork;
    public MovieBO(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Movie GetMovie(int id) => _unitOfWork.MovieRepository.GetById(id);

    public IEnumerable<Movie> SearchForMovies(string title, List<string> genres)
    {
        var movies = new List<Movie>();
        genres = genres.Select(x => { x = x.ToLower(); return x; }).ToList();

        if (!string.IsNullOrEmpty(title))
        {
            movies.AddRange(_unitOfWork.MovieRepository.Find(m => m.Title.Contains(title))
                .Take(10)); // limit it to 10 for now; further a rule can be put in place
        }

        _unitOfWork.MovieGenreRepository.GetAll();
        _unitOfWork.GenreRepository.GetAll();
        if (genres != null && genres.Count > 0)
        {
            if (movies.Count > 0)
            {
                movies = movies.FindAll(m => m.GenreMovie.FirstOrDefault(gm => genres.Contains(gm.Genre.Name.ToLower())) != null);
            }
            else
            {
                movies.AddRange(_unitOfWork.MovieRepository.Find(m => m.GenreMovie.FirstOrDefault(gm => genres.Contains(gm.Genre.Name.ToLower())) != null));
            }
        }

        return this.TransformNonCircular(movies);
    }

    public decimal GetAverageRating(Movie movie)
    {
        decimal avgRating = 0;
        var movieReviews = _unitOfWork.ReviewRepository.Find(r => r.ParentMovieId == movie.Id);

        if (movieReviews.Count() > 0)
        {
            var sumReviews = movieReviews.Sum(r => r.Rating);
            avgRating = sumReviews / movieReviews.Count();
        }


        return avgRating;
    }

    public IEnumerable<Movie> TransformNonCircular(IEnumerable<Movie> movies)
    {
        // Load all chilren
        _unitOfWork.MovieGenreRepository.GetAll();
        _unitOfWork.GenreRepository.GetAll();
        _unitOfWork.ReviewRepository.GetAll();
        _unitOfWork.UserRepository.GetAll();

        foreach (var movie in movies)
        {
            foreach(var review in movie.Reviews)
            {
                review.Movie = null;
                review.User = null;
            }
            foreach(var movieGenre in movie.GenreMovie)
            {
                movieGenre.Movie = null;
                if (movieGenre.Genre != null)
                {
                    movieGenre.Genre.MovieGenre = null;
                }
            }
        }

        return movies;
    }

    public IEnumerable<Movie> GetAllNonCircular()
    {
        // Load all chilren
        var movies = _unitOfWork.MovieRepository
            .GetAll();
        _unitOfWork.MovieGenreRepository.GetAll();
        _unitOfWork.GenreRepository.GetAll();
        _unitOfWork.ReviewRepository.GetAll();
        _unitOfWork.UserRepository.GetAll();

        foreach (var movie in movies)
        {
            foreach(var review in movie.Reviews)
            {
                review.Movie = null;
                review.User = null;
            }
            foreach(var movieGenre in movie.GenreMovie)
            {
                movieGenre.Movie = null;
                if (movieGenre.Genre != null)
                {
                    movieGenre.Genre.MovieGenre = null;
                }
            }
        }

        return movies;
    }

    public IEnumerable<Movie> GetTop5MoviesByRating()
    {
        return this.GetAllNonCircular()
            .Where(m => m.Reviews.Count() > 0)
            .OrderByDescending(M => (M.Reviews.Sum(r => r.Rating) / M.Reviews.Count()))
            .ThenBy(M => M.Title).Take(5);
    }
}
