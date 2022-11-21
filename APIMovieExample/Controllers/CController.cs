using System.Linq;
using APIMovie.ModelViews;
using APIMovie.Validators;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Business;
using MovieAPI.Interfaces;

namespace APIMovieExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CController : ControllerBase
    {
        private UserBO _userBO;

        public CController(IUnitOfWork unitOfWork)
        {
            _userBO = new UserBO(unitOfWork);
        }

        [HttpGet]
        public IActionResult SearchForMovie([FromQuery]UserQueryParameter input)
        {
            var inputValidator = new UserQueryParameterValidator();
            var validationResult = inputValidator.Validate(input);

            if (!validationResult.IsValid)
                return BadRequest("Invalid input");

            var user = _userBO.SearchForUser(input.Username);
            if (user == null)
                return NotFound();
                 

            var selectedMovies = _userBO.GetTop5MoviesByRating(user);

            return selectedMovies.Count() > 0
                ? Ok(selectedMovies)
                : NotFound();
        }

    }
}
