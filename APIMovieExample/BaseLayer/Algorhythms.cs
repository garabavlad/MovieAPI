using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.EntityLayer;

namespace APIMovieExample.BaseLayer
{
    public class Algorhythms : BaseBO
    {
        // This class will be used to store the all the algorhyths used in the application. This should be extended to a separate layer

        public static String GetReviewRating(decimal rating)
        {
            // This approximation can be done in a lot of ways, including a lot of if else statements, but I'll just a more complex one:
            // We will ceil the rating and will see the difference between ceiled value and the actual rating. Each difference mean a different rating value:
            // a difference between 0 and 0.25 means that the value is close to the ceiled value so keep as is.
            // a difference between 0.251 and 0.75 means that the value is close to the half ceiled value.
            // a difference more than 0.751 is basically truncated rating (or ceiled - 1).
            String roundedRating = null;
            Decimal ceiledRating;
            Boolean canBeProcessed = true;

            if (rating < 1 || rating > 5)
            {
                canBeProcessed = false; // ignore invalid ratings 
            }

            if (canBeProcessed)
            {
                ceiledRating = Math.Ceiling(rating);

                if (ceiledRating - rating <= 0.25m)
                {
                    roundedRating = ceiledRating.ToString();
                }
                else if (ceiledRating - rating <= 0.75m)
                {
                    roundedRating = (ceiledRating - 0.5m).ToString();
                }
                else
                {
                    roundedRating = (ceiledRating - 1m).ToString();
                }
            }
           

            return roundedRating;
        }

        public static IEnumerable<MovieModel> ApplySearchAlgorhythm(IEnumerable<MovieModel> movies, String title)
        {
            // here we could use advanced searching algorhythms
            return movies.Where(M => M.Title.Contains(title));
        }

        public static IEnumerable<MovieModel> ApplyGenreFilter(IEnumerable<MovieModel> movies, List<String> genres)
        {
            // here should refubrish later with maybe a IEqualityComparer
            var tmpMovies = new List<MovieModel>();
            if (genres != null && genres.Count > 0)
            {
                foreach (var movie in movies)
                {
                    foreach (var movieGenre in movie._Genres)
                    {
                        foreach (var searchGenre in genres)
                        {
                            if (movieGenre.Name.ToLower() == searchGenre.ToLower()
                                && !tmpMovies.Contains(movie))
                            {
                                tmpMovies.Add(movie);
                            }
                        }
                    }
                }
            }
            return tmpMovies;
        }
    }
}
