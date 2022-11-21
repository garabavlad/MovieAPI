using System.Text.Json.Serialization;

namespace MovieAPI.Models;

public class User
{
    public User()
    {
        Reviews = new List<Review>();
    }
    public User(String username)
    {
        Username = username;
        Reviews = new List<Review>();
    }

    public long Id { get; set; }

    public string Username { get; set; }

    public virtual List<Review> Reviews { get; set; }

}
