using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using APIMovieExample.BaseLayer;

namespace APIMovieExample.EntityLayer
{
    public class UserModel : BaseModel
    {
        private long _id;
        private String _username;
        private List<ReviewModel> _reviews;

        public UserModel(String username = null)
        {
            if (!String.IsNullOrEmpty(username))
            {
                _username = username;
            }
        }

        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }

        [JsonIgnore]
        public virtual List<ReviewModel> Reviews
        {
            get { return _reviews; }
            set
            {
                _reviews = value;
            }
        }
    }
}
