using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Business;
using MovieAPI.Interfaces;

namespace APIMovieExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BController : ControllerBase
    {
        private MovieBO _movieBO;

        public BController(IUnitOfWork unitOfWork)
        {
            _movieBO = new MovieBO(unitOfWork);
        }

        [HttpGet]
        public IActionResult SearchForMovie()
        {
            var selectedMovies = _movieBO.GetTop5MoviesByRating();

            return selectedMovies.Count() > 0
                ? Ok (selectedMovies)
                : NotFound();
        }
    }
}
