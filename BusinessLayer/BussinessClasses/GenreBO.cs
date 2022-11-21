using MovieAPI.Interfaces;

namespace MovieAPI.Business;
public class GenreBO
{
    private IUnitOfWork _unitOfWork;
    public GenreBO(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

}
