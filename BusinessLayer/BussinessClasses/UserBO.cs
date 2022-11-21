using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class UserBO
{
    private IUnitOfWork _unitOfWork;
    public UserBO(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public User GetEntity(int Id)
    {
        return _unitOfWork.UserRepository.GetById(Id);
    }

    public User SearchForUser(String username)
    {
        return _unitOfWork.UserRepository.Find(u => u.Username.ToLower() == username.ToLower()).FirstOrDefault();
    }

    public IEnumerable<Movie> GetTop5MoviesByRating(User user)
    {
        var movieIds = _unitOfWork.ReviewRepository
            .GetAll()
            .Where(rw => rw.ParentUserId == user.Id)
            .OrderByDescending(R => R.Rating)
            .ThenBy(R => R.Movie.Title)
            .Distinct()
            .Select(R => R.ParentMovieId)
            .Take(5)
            .ToList();

        var movieBO = new MovieBO(_unitOfWork);
        var movieList = new List<Movie>();
        var nonCircularMovies = movieBO.GetAllNonCircular();

        foreach (var movieId in movieIds)
            movieList.Add(nonCircularMovies.First(m => m.Id == movieId));

        _unitOfWork.MovieGenreRepository.GetAll(); // load movie genres
   
        return movieList;
    }
}
