using System.Text.Json.Serialization;
using MovieAPI.Core;

namespace MovieAPI.Models;

public class Movie
{
    public long Id { get; set; }
    public String Title { get; set; }
    public String RunningTime { get; set; } // might need to change this to decimal later on

    //[NotMapped]
    //public IEnumerable<MovieGenre> Genres { get; set; }

    [JsonIgnore]
    public IEnumerable<MovieGenre> _Genres { get; set; }

    public String Genres
    {
        get
        {
            // Here could use a StringBuilder for better performance but cbb
            String genresToReturn = String.Empty;

            if (_Genres != null)
            {
                foreach (var genreObj in _Genres)
                {
                    if (!String.IsNullOrEmpty(genresToReturn))
                        genresToReturn += ", "; // Append comma to all but first genre

                    genresToReturn += genreObj.Name;
                }
            }

            return genresToReturn;
        }
    }

    public int ReleaseYear { get; set; }

    [JsonIgnore]
    public virtual List<Review> Reviews { get; set; }

    public Movie()
    {
        _Genres = new List<MovieGenre>();
    }

    public Movie(string name = null, string releaseYear = null, List<string> genres = null, List<Review> reviews = null)
    {
        if (!String.IsNullOrEmpty(name))
        {
            Title = name;
        }

        if (reviews != null && reviews.Count > 0)
        {
            Reviews = reviews;
        }
        else
        {
            Reviews = new List<Review>();
        }

        if (!String.IsNullOrEmpty(releaseYear))
        {
            Int32.TryParse(releaseYear, out int parsedYear);
            ReleaseYear = parsedYear;
        }

        if (genres != null && genres.Count > 0)
        {
            //Genres = genres.ToArray(); // tbc
        }
        else
        {
            _Genres = new List<MovieGenre>();
        }
    }

    public String AverageRating
    {
        get
        {
            String avgRating = "1"; // 1 by default
            Decimal total = 0;

            if (Reviews != null && Reviews.Count > 0)
            {
                foreach (var review in Reviews)
                {
                    Decimal.TryParse(review.Rating, out decimal parsedVal);
                    total += parsedVal;
                }

                avgRating = Algorhythms.GetReviewRating(total / Reviews.Count).ToString();
            }

            return avgRating;
        }
    }
}
