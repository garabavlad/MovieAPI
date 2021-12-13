using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<MovieModel>().HasMany(M => M.Reviews).WithOne(P => P.ParentMovie).HasForeignKey(P => P.ParentMovieId);
            modelBuilder.Entity<MovieModel>().HasMany(M => M._Genres).WithOne(P => P.ParentMovie).HasForeignKey(P => P.ParentMovieId);
            modelBuilder.Entity<UserModel>().HasMany(M => M.Reviews).WithOne(P => P.ParentUser).HasForeignKey(P => P.ParentUserId);

            modelBuilder.Seed();
        }

        public virtual DbSet<MovieModel> Movies { get; set; }
        public virtual DbSet<ReviewModel> Reviews { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<MovieGenreModel> MovieGenres { get; set; }
    }
}
