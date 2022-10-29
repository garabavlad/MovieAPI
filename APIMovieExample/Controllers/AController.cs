using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovie.Controllers;
using APIMovieExample.DataLayer;
using APIMovieExample.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Business;
using MovieAPI.Models;

namespace APIMovieExample.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AController : APIMovieController
    {
        private MovieBO _movieBO;
        //private readonly MovieDatabaseContext _context;

        public AController(MovieDatabaseContext context)
        {
            _movieBO = new MovieBO(context);
            //_context = context;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> SearchForMovie([FromQuery]MovieSearchQueryParameter input)
        {
            IActionResult result;
            IEnumerable<Movie> selectedMovies;

            if (input.IsValid)
            {
                selectedMovies = _movieBO.SearchForMovies(input.Title, input.Rating, input.ReleaseYear, input.Genres);

                if (selectedMovies.Count() > 0)
                {
                    result = Ok(selectedMovies);

                }
                else
                {
                    result = NotFound();
                }
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }
    }
}
