namespace MovieAPI.Core;

/// <summary>
/// This class will be used to store the all the algorhyths used in the application. This should be extended to a separate layer;
/// </summary>
public class Algorhythms
{
    public static Decimal GetReviewRating(decimal rating)
    {
        // This approximation can be done in a lot of ways, including a lot of if else statements, but I'll just a more complex one:
        // We will ceil the rating and will see the difference between ceiled value and the actual rating. Each difference mean a different rating value:
        // a difference between 0 and 0.25 means that the value is close to the ceiled value so keep as is.
        // a difference between 0.251 and 0.75 means that the value is close to the half ceiled value.
        // a difference more than 0.751 is basically truncated rating (or ceiled - 1).
        Decimal ceiledRating, returnedRating = 0;

        if (rating < 1 || rating > 5)
        {
            ceiledRating = Math.Ceiling(rating);

            if (ceiledRating - rating <= 0.25m)
            {
                returnedRating = ceiledRating;
            }
            else if (ceiledRating - rating <= 0.75m)
            {
                returnedRating = (ceiledRating - 0.5m);
            }
            else
            {
                returnedRating = (ceiledRating - 1m);
            }
        }
       
        return returnedRating;
    }
}
