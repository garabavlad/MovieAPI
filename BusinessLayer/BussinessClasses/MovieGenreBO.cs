using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class MovieGenreBO
{
    private IUnitOfWork _unitOfWork;
    public MovieGenreBO(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<MovieGenre> SearchForMovieGenres_ByParentId(long movieId)
    {
        return _unitOfWork.MovieGenreRepository.Find(mg => mg.ParentMovieId == movieId);
    }
}
