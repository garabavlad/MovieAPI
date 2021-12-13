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
    public class BController : APIMovieController
    {
        private MovieBO _movieBO;
        //private readonly MovieDatabaseContext _context;

        public BController(MovieDatabaseContext context)
        {
            _movieBO = new MovieBO(context);
            //_context = context;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> SearchForMovie()
        {
            IActionResult result;
            IEnumerable<MovieModel> selectedMovies;

            selectedMovies = _movieBO.GetTop5MoviesByRating();

            if (selectedMovies.Count() > 0)
            {
                result = Ok(selectedMovies);

            }
            else
            {
                result = NotFound();
            }


            return result;
        }
    }
}
