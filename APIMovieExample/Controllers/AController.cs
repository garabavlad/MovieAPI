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
    public class AController : ControllerBase
    {
        private MovieBO _movieBO;

        public AController(IUnitOfWork unitOfWork)
        {
            _movieBO = new MovieBO(unitOfWork);
        }

        [HttpGet]
        public IActionResult SearchForMovie([FromQuery] MovieSearchQueryParameter input)
        {
            var inputValidator = new MovieSearchQueryParameterValidator();
            var validationResult = inputValidator.Validate(input);

            if (!validationResult.IsValid)
                return BadRequest("Invalid input");


            var selectedMovies = _movieBO.SearchForMovies(input.Title, input.Genres);

            return selectedMovies.Count() > 0 
                ? Ok(selectedMovies) 
                : NotFound();
        }
    }
}
