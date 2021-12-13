using System;
using System.Text.Json.Serialization;
using APIMovieExample.BaseLayer;

namespace APIMovieExample.EntityLayer
{
    public class MovieGenreModel : BaseModel
    {
        public long Id { get; set; }

        [JsonIgnore]
        public long ParentMovieId { get; set; }

        [JsonIgnore]
        public MovieModel ParentMovie { get; set; }
        public String Name { get; set; }

        public MovieGenreModel() { }
    }
}
