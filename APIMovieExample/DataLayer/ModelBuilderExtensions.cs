using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMovieExample.EntityLayer;
using Microsoft.EntityFrameworkCore;
using static APIMovieExample.BaseLayer.BaseEnums;

namespace APIMovieExample.DataLayer
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>().HasData(
                new MovieModel { Id = 1, Title = "Movie1", RunningTime = "89", ReleaseYear = 2010},
                new MovieModel { Id = 2, Title = "Movie2", RunningTime = "78", ReleaseYear = 2000},
                new MovieModel { Id = 3, Title = "Movie3", RunningTime = "122", ReleaseYear = 2011},
                new MovieModel { Id = 4, Title = "Movie4", RunningTime = "90", ReleaseYear = 2012},
                new MovieModel { Id = 5, Title = "Movie5", RunningTime = "94", ReleaseYear = 2013},
                new MovieModel { Id = 11, Title = "Movie6", RunningTime = "89", ReleaseYear = 2013},
                new MovieModel { Id = 6, Title = "Movie7", RunningTime = "77", ReleaseYear = 2013},
                new MovieModel { Id = 14, Title = "Movie7", RunningTime = "88", ReleaseYear = 2013},
                new MovieModel { Id = 7, Title = "Movie8", RunningTime = "87", ReleaseYear = 2013},
                new MovieModel { Id = 8, Title = "Movie9", RunningTime = "111", ReleaseYear = 2013},
                new MovieModel { Id = 9, Title = "Movie10", RunningTime = "121", ReleaseYear = 2013},
                new MovieModel { Id = 10, Title = "Movie11", RunningTime = "100", ReleaseYear = 2013},
                new MovieModel { Id = 12, Title = "Movie12", RunningTime = "99", ReleaseYear = 2013},
                new MovieModel { Id = 13, Title = "Movie13", RunningTime = "97", ReleaseYear = 2013}
                );

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Username = "Vlad"},
                new UserModel { Id = 2, Username = "John"},
                new UserModel { Id = 3, Username = "Alison"}
                );

            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel { Id = 1, ParentMovieId = 1, ParentUserId = 1, Rating = "4"},
                new ReviewModel { Id = 2, ParentMovieId = 1, ParentUserId = 1, Rating = "3"},
                new ReviewModel { Id = 3, ParentMovieId = 2, ParentUserId = 2, Rating = "5"},
                new ReviewModel { Id = 4, ParentMovieId = 2, ParentUserId = 2, Rating = "4"},
                new ReviewModel { Id = 5, ParentMovieId = 3, ParentUserId = 2, Rating = "1"},
                new ReviewModel { Id = 6, ParentMovieId = 1, ParentUserId = 1, Rating = "2"},
                new ReviewModel { Id = 7, ParentMovieId = 1, ParentUserId = 1, Rating = "3"},
                new ReviewModel { Id = 8, ParentMovieId = 1, ParentUserId = 1, Rating = "4"},
                new ReviewModel { Id = 9, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new ReviewModel { Id = 10, ParentMovieId = 3, ParentUserId = 3, Rating = "5"},
                new ReviewModel { Id = 11, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new ReviewModel { Id = 12, ParentMovieId = 5, ParentUserId = 1, Rating = "3"},
                new ReviewModel { Id = 13, ParentMovieId = 6, ParentUserId = 1, Rating = "3"},
                new ReviewModel { Id = 14, ParentMovieId = 6, ParentUserId = 2, Rating = "3"},
                new ReviewModel { Id = 15, ParentMovieId = 3, ParentUserId = 2, Rating = "2"},
                new ReviewModel { Id = 16, ParentMovieId = 7, ParentUserId = 2, Rating = "2"},
                new ReviewModel { Id = 17, ParentMovieId = 8, ParentUserId = 1, Rating = "5"},
                new ReviewModel { Id = 18, ParentMovieId = 3, ParentUserId = 1, Rating = "4"},
                new ReviewModel { Id = 19, ParentMovieId = 9, ParentUserId = 1, Rating = "3"},
                new ReviewModel { Id = 20, ParentMovieId = 10, ParentUserId = 2, Rating = "3"},
                new ReviewModel { Id = 21, ParentMovieId = 11, ParentUserId = 2, Rating = "3"},
                new ReviewModel { Id = 22, ParentMovieId = 12, ParentUserId = 1, Rating = "2"},
                new ReviewModel { Id = 23, ParentMovieId = 11, ParentUserId = 1, Rating = "5"},
                new ReviewModel { Id = 24, ParentMovieId = 8, ParentUserId = 1, Rating = "5"},
                new ReviewModel { Id = 25, ParentMovieId = 2, ParentUserId = 1, Rating = "5"},
                new ReviewModel { Id = 26, ParentMovieId = 2, ParentUserId = 3, Rating = "5"},
                new ReviewModel { Id = 27, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new ReviewModel { Id = 28, ParentMovieId = 4, ParentUserId = 3, Rating = "3"},
                new ReviewModel { Id = 29, ParentMovieId = 5, ParentUserId = 2, Rating = "3"},
                new ReviewModel { Id = 30, ParentMovieId = 3, ParentUserId = 2, Rating = "4"}
                );

            modelBuilder.Entity<MovieGenreModel>().HasData(
                new MovieGenreModel() { Id = 1, ParentMovieId = 13, Name = "Romance" },
                new MovieGenreModel() { Id = 2, ParentMovieId = 1, Name = "Action" },
                new MovieGenreModel() { Id = 3, ParentMovieId = 3, Name = "Mystery" },
                new MovieGenreModel() { Id = 4, ParentMovieId = 2, Name = "Action" },
                new MovieGenreModel() { Id = 5, ParentMovieId = 4, Name = "Fantasy" },
                new MovieGenreModel() { Id = 6, ParentMovieId = 5, Name = "Action" },
                new MovieGenreModel() { Id = 7, ParentMovieId = 6, Name = "Action" },
                new MovieGenreModel() { Id = 8, ParentMovieId = 4, Name = "Action" },
                new MovieGenreModel() { Id = 9, ParentMovieId = 7, Name = "Fantasy" },
                new MovieGenreModel() { Id = 11, ParentMovieId = 8, Name = "Mystery" },
                new MovieGenreModel() { Id = 10, ParentMovieId = 9, Name = "Romance" },
                new MovieGenreModel() { Id = 12, ParentMovieId = 10, Name = "Action" },
                new MovieGenreModel() { Id = 13, ParentMovieId = 11, Name = "Fantasy" },
                new MovieGenreModel() { Id = 14, ParentMovieId = 12, Name = "Action" },
                new MovieGenreModel() { Id = 15, ParentMovieId = 13, Name = "Mystery" },
                new MovieGenreModel() { Id = 16, ParentMovieId = 12, Name = "Action" },
                new MovieGenreModel() { Id = 17, ParentMovieId = 2, Name = "Action" },
                new MovieGenreModel() { Id = 18, ParentMovieId = 13, Name = "Romance" },
                new MovieGenreModel() { Id = 19, ParentMovieId = 6, Name = "Romance" }

            );
        }
    }
}
