using MovieAPI.Interfaces;

namespace MovieAPI.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly MovieDatabaseContext _context;
    
    public UnitOfWork(MovieDatabaseContext context)
    {
        _context = context;
        GenreRepository = new GenreRepository(_context);
        MovieGenreRepository = new MovieGenreRepository(_context);
        MovieRepository = new MovieRepository(_context);
        ReviewRepository = new ReviewRepository(_context);
        UserRepository = new UserRepository(_context);
    }

    public IGenreRepository GenreRepository { get; private set; }
    public IMovieGenreRepository MovieGenreRepository { get; private set; }
    public IMovieRepository MovieRepository { get; private set; }
    public IReviewRepository ReviewRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
