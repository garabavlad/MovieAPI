namespace MovieAPI.Models;

public class Genre
{
    public Genre() { }
    public Genre(string name)
    {
        Name = name;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public MovieGenre MovieGenre { get; set; }
}
