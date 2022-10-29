using System;
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
    public class DController : APIMovieController
    {
        private MovieBO _movieBO;
        private UserBO _userBO;
        private ReviewBO _reviewBO;
        //private readonly MovieDatabaseContext _context;

        public DController(MovieDatabaseContext context)
        {
            _movieBO = new MovieBO(context);
            _userBO = new UserBO(context);
            _reviewBO = new ReviewBO(context);
            //_context = context;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<IActionResult> AddOrUpdateReview([FromQuery]RatingQueryParameter input)
        {
            IActionResult result;
            IEnumerable<Movie> selectedMovies;

            if (input.IsValid)
            {
                Int32.TryParse(input.Rating, out int parsedRating);
                var user = _userBO.SearchForUser(input.Username);
                Movie movie = null;
                
                if (!String.IsNullOrEmpty(input.MovieTitle))
                    movie = _movieBO.SearchForMovies(input.MovieTitle).FirstOrDefault();

                // Check for rating if it is between 1 and 5
                if (parsedRating < 1 || parsedRating > 5)
                {
                    result = BadRequest();
                }
                else
                {
                    if (user == null || movie == null)
                    {
                        result = NotFound();
                    }
                    else
                    {
                        // we have a valid review
                        _reviewBO.InsertReview(user, movie, parsedRating);

                        result = Ok();
                    }
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
