using System;
using MovieAPI.Core;

namespace APIMovieExample.QueryParameters
{
    public class RatingQueryParameter : QueryParameterBase
    {
        public String Username { get; set; }
        public String MovieTitle { get; set; }
        public String Rating { get; set; }

        public Boolean IsValid
        {
            get
            {
                return !String.IsNullOrEmpty(Username)
                    || !String.IsNullOrEmpty(MovieTitle)
                    || !String.IsNullOrEmpty(Rating);
            }
        }
    }
}
