using System.Collections.Generic;

namespace APIMovie.ModelViews
{
    public class MovieSearchQueryParameter
    {
        public string Title { get; set; }
        public List<string> Genres { get; set; } 
    }
}
