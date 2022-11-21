namespace MovieAPI.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenreRepository GenreRepository { get; }
    IMovieGenreRepository MovieGenreRepository { get; }
    IMovieRepository MovieRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IUserRepository UserRepository { get; }
    int Save();
}
