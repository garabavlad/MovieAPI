using System.Text.Json.Serialization;

namespace MovieAPI.Models;

public class MovieGenre
{
    public long Id { get; set; }

    [JsonIgnore]
    public long ParentMovieId { get; set; }

    [JsonIgnore]
    public Movie ParentMovie { get; set; }
    public String Name { get; set; }

    public MovieGenre() { }
}
