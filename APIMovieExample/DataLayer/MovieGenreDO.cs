using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.DataLayer
{
    public class MovieGenreDO : BaseDO
    {
        private readonly MovieDatabaseContext _movieContext;

        public MovieGenreDO(DbContext context)
        {
            _movieContext = (MovieDatabaseContext)context;

            _movieContext.Database.EnsureCreated();
        }

        public IEnumerable<MovieGenreModel> RetrieveMovieGenres(long parentId)
        {
            IEnumerable<MovieGenreModel> genres = _movieContext.MovieGenres;

            genres = genres.Where(x => x.ParentMovieId == parentId).ToList();


            return genres;
        }

    }
}
