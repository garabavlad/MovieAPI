using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{
    public class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext() : base()
        {

        }

        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasMany(M => M.Reviews).WithOne(P => P.ParentMovie).HasForeignKey(P => P.ParentMovieId);
            modelBuilder.Entity<Movie>().HasMany(M => M._Genres).WithOne(P => P.ParentMovie).HasForeignKey(P => P.ParentMovieId);
            modelBuilder.Entity<User>().HasMany(M => M.Reviews).WithOne(P => P.ParentUser).HasForeignKey(P => P.ParentUserId);

            modelBuilder.Seed();
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
    }
}
