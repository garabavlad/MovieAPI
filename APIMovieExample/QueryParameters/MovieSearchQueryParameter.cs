using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;

namespace APIMovieExample.QueryParameters
{
    public class MovieSearchQueryParameter : QueryParameterBase
    {
        public String Title { get; set; }
        public String Rating { get; set; }
        public String ReleaseYear { get; set; }
        public List<String> Genres { get; set; }

        public Boolean IsValid
        {
            get
            {
                return !String.IsNullOrEmpty(Title)
                    || !String.IsNullOrEmpty(Rating)
                    || !String.IsNullOrEmpty(ReleaseYear)
                    || (Genres != null && Genres.Count > 0);
            }
        }
    }
}
