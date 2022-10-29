using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Core;

public class BaseEnums
{
    //public enum MovieGenre
    //{
    //    Unknown = 0,
    //    Action = 1,
    //    Comedy = 2,
    //    Drama = 3,
    //    Fantasy = 4,
    //    Horror = 5,
    //    Mystery = 6,
    //    Romance = 7,
    //    Thriller = 8,
    //}

    public static readonly string[] MovieGenres = new[]
    {
        "Action",
        "Comedy",
        "Drama",
        "Fantasy",
        "Horror",
        "Mystery",
        "Romance",
        "Thriller"
    };

    public static Boolean isValidMovieGenre(String input)
    {
        Boolean isValid = false;

        foreach (var genre in MovieGenres)
        {
            if (String.Equals(genre.ToLower(), input.ToLower()))
                isValid = true;
        }    

        return isValid;
    }
}
