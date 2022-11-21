using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasOne(M => M.MovieGenre).WithOne(P => P.Genre).HasForeignKey<MovieGenre>(P => P.ParentGenreId);
        modelBuilder.Entity<Movie>().HasMany(M => M.Reviews).WithOne(P => P.Movie).HasForeignKey(P => P.ParentMovieId);
        modelBuilder.Entity<Movie>().HasMany(M => M.GenreMovie).WithOne(P => P.Movie).HasForeignKey(P => P.ParentMovieId);
        modelBuilder.Entity<User>().HasMany(U => U.Reviews).WithOne(P => P.User).HasForeignKey(P => P.ParentUserId);

        modelBuilder.Seed();
    }

    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<MovieGenre> MovieGenres { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
}
