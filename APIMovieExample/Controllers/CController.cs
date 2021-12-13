using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIMovieExample.Base;
using APIMovieExample.BussinessLayer;
using APIMovieExample.DataLayer;
using APIMovieExample.EntityLayer;
using APIMovieExample.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIMovieExample.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CController : APIMovieController
    {
        //private MovieBO _movieBO;
        private UserBO _userBO;
        //private readonly MovieDatabaseContext _context;

        public CController(MovieDatabaseContext context)
        {
            //_movieBO = new MovieBO(context);
            _userBO = new UserBO(context);
            //_context = context;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> SearchForMovie([FromQuery]RatingQueryParameter input)
        {
            IActionResult result;
            IEnumerable<MovieModel> selectedMovies;

            if (input.IsValid)
            {
                var user = _userBO.SearchForUser(input.Username);

                if (user != null)
                {
                    _userBO.SetEntityContext(user);
                    selectedMovies = _userBO.GetTop5MoviesByRating();

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
