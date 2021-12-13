using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;
using APIMovieExample.DataLayer;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.BussinessLayer
{
    public class MovieGenreBO : BaseBO
    {
        private DbContext _context;
        public MovieGenreBO(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieGenreModel> SearchForGenres(long parentId)
        {
            MovieGenreDO reviewDO = new MovieGenreDO(_context);
            IEnumerable<MovieGenreModel> genres = reviewDO.RetrieveMovieGenres(parentId);

            return genres;
        }

    }
}
