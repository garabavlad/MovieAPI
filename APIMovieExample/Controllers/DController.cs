using APIMovie.ModelViews;
using APIMovie.Validators;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Business;
using MovieAPI.Interfaces;

namespace APIMovieExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DController : ControllerBase
    {
        private MovieBO _movieBO;
        private UserBO _userBO;
        private ReviewBO _reviewBO;

        public DController(IUnitOfWork unitOfWork)
        {
            _movieBO = new MovieBO(unitOfWork);
            _userBO = new UserBO(unitOfWork);
            _reviewBO = new ReviewBO(unitOfWork);
        }

        [HttpPost]
        [HttpPut]
        public IActionResult AddOrUpdateReview([FromBody] ReviewUpdateRequest input)
        {
            var inputValidator = new ReviewUpdateRequestValidator();
            var validationResult = inputValidator.Validate(input);

            if (!validationResult.IsValid)
                return BadRequest("Invalid input");

            var user = _userBO.SearchForUser(input.Username);
            var movie = _movieBO.GetMovie(input.MovieId);

            if (user == null || movie == null)
                return NotFound();


            var savedEntitiesCount = _reviewBO.InsertReview(user, movie, input.Rating);

            return savedEntitiesCount > 0 
                ? Ok() 
                : BadRequest();
        }
    }
}
