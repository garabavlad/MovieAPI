using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Business;

public class ReviewBO
{
    private IUnitOfWork _unitOfWork;
    public ReviewBO(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Review> GetAllNonCircular()
    {
        var reviews = _unitOfWork.ReviewRepository
            .GetAll();

        foreach (var review in reviews)
        {
            review.Movie.Reviews = null;
            review.User.Reviews = null;
        }

        return reviews;
    }

    public int InsertReview(User user, Movie movie, int rating)
    {
        var existingReview = _unitOfWork.ReviewRepository.Find(r => r.ParentUserId == user.Id && r.ParentMovieId == movie.Id)
            .FirstOrDefault();

        if (existingReview != null)
        {
            existingReview.Rating = rating;
            _unitOfWork.ReviewRepository.Update(existingReview);
        }
        else
        {
            var newReview = new Review(rating, movie, user);
            _unitOfWork.ReviewRepository.Add(newReview);
        }

        return _unitOfWork.Save();
    }
}
