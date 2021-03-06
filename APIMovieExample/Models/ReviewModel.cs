using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;

namespace APIMovieExample.EntityLayer
{
    public class ReviewModel : BaseModel
    {
        private decimal _rating;

        public long Id { get; set; }

        [JsonIgnore]
        public long ParentMovieId { get; set; }

        [JsonIgnore]
        public long ParentUserId { get; set; }

        [JsonIgnore]
        public MovieModel ParentMovie { get; set; }

        [JsonIgnore]
        public UserModel ParentUser { get; set; }

        public ReviewModel(String rating = null, long parentMovieId = 0, long parentUserId = 0)
        {
            if (!String.IsNullOrEmpty(rating))
            {
                Decimal.TryParse(rating, out decimal parsedDec);
                _rating = parsedDec;
            }
            if (parentMovieId != 0)
            {
                ParentMovieId = parentMovieId;
            }
            if (parentUserId != 0)
            {
                ParentUserId = parentUserId;
            }
        }

        public String Rating // enforcing String type to increase its flexibility
        {
            get 
            { 
                return Algorhythms.GetReviewRating(_rating); // use algorhythms methods for getter / setter
            }
            set 
            {
                Decimal.TryParse(value, out decimal parsedRating);
                _rating = parsedRating;
            }
        }
    }
}
