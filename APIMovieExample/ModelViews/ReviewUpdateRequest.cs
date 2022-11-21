namespace APIMovie.ModelViews
{
    public class ReviewUpdateRequest
    {
        public string Username { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
    }
}
