using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace APIMovieExample.DataLayer
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Movie1", RunningTime = "89", ReleaseYear = 2010},
                new Movie { Id = 2, Title = "Movie2", RunningTime = "78", ReleaseYear = 2000},
                new Movie { Id = 3, Title = "Movie3", RunningTime = "122", ReleaseYear = 2011},
                new Movie { Id = 4, Title = "Movie4", RunningTime = "90", ReleaseYear = 2012},
                new Movie { Id = 5, Title = "Movie5", RunningTime = "94", ReleaseYear = 2013},
                new Movie { Id = 11, Title = "Movie6", RunningTime = "89", ReleaseYear = 2013},
                new Movie { Id = 6, Title = "Movie7", RunningTime = "77", ReleaseYear = 2013},
                new Movie { Id = 14, Title = "Movie7", RunningTime = "88", ReleaseYear = 2013},
                new Movie { Id = 7, Title = "Movie8", RunningTime = "87", ReleaseYear = 2013},
                new Movie { Id = 8, Title = "Movie9", RunningTime = "111", ReleaseYear = 2013},
                new Movie { Id = 9, Title = "Movie10", RunningTime = "121", ReleaseYear = 2013},
                new Movie { Id = 10, Title = "Movie11", RunningTime = "100", ReleaseYear = 2013},
                new Movie { Id = 12, Title = "Movie12", RunningTime = "99", ReleaseYear = 2013},
                new Movie { Id = 13, Title = "Movie13", RunningTime = "97", ReleaseYear = 2013}
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Vlad"},
                new User { Id = 2, Username = "John"},
                new User { Id = 3, Username = "Alison"}
                );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, ParentMovieId = 1, ParentUserId = 1, Rating = "4"},
                new Review { Id = 2, ParentMovieId = 1, ParentUserId = 1, Rating = "3"},
                new Review { Id = 3, ParentMovieId = 2, ParentUserId = 2, Rating = "5"},
                new Review { Id = 4, ParentMovieId = 2, ParentUserId = 2, Rating = "4"},
                new Review { Id = 5, ParentMovieId = 3, ParentUserId = 2, Rating = "1"},
                new Review { Id = 6, ParentMovieId = 1, ParentUserId = 1, Rating = "2"},
                new Review { Id = 7, ParentMovieId = 1, ParentUserId = 1, Rating = "3"},
                new Review { Id = 8, ParentMovieId = 1, ParentUserId = 1, Rating = "4"},
                new Review { Id = 9, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new Review { Id = 10, ParentMovieId = 3, ParentUserId = 3, Rating = "5"},
                new Review { Id = 11, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new Review { Id = 12, ParentMovieId = 5, ParentUserId = 1, Rating = "3"},
                new Review { Id = 13, ParentMovieId = 6, ParentUserId = 1, Rating = "3"},
                new Review { Id = 14, ParentMovieId = 6, ParentUserId = 2, Rating = "3"},
                new Review { Id = 15, ParentMovieId = 3, ParentUserId = 2, Rating = "2"},
                new Review { Id = 16, ParentMovieId = 7, ParentUserId = 2, Rating = "2"},
                new Review { Id = 17, ParentMovieId = 8, ParentUserId = 1, Rating = "5"},
                new Review { Id = 18, ParentMovieId = 3, ParentUserId = 1, Rating = "4"},
                new Review { Id = 19, ParentMovieId = 9, ParentUserId = 1, Rating = "3"},
                new Review { Id = 20, ParentMovieId = 10, ParentUserId = 2, Rating = "3"},
                new Review { Id = 21, ParentMovieId = 11, ParentUserId = 2, Rating = "3"},
                new Review { Id = 22, ParentMovieId = 12, ParentUserId = 1, Rating = "2"},
                new Review { Id = 23, ParentMovieId = 11, ParentUserId = 1, Rating = "5"},
                new Review { Id = 24, ParentMovieId = 8, ParentUserId = 1, Rating = "5"},
                new Review { Id = 25, ParentMovieId = 2, ParentUserId = 1, Rating = "5"},
                new Review { Id = 26, ParentMovieId = 2, ParentUserId = 3, Rating = "5"},
                new Review { Id = 27, ParentMovieId = 3, ParentUserId = 3, Rating = "4"},
                new Review { Id = 28, ParentMovieId = 4, ParentUserId = 3, Rating = "3"},
                new Review { Id = 29, ParentMovieId = 5, ParentUserId = 2, Rating = "3"},
                new Review { Id = 30, ParentMovieId = 3, ParentUserId = 2, Rating = "4"}
                );

            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre() { Id = 1, ParentMovieId = 13, Name = "Romance" },
                new MovieGenre() { Id = 2, ParentMovieId = 1, Name = "Action" },
                new MovieGenre() { Id = 3, ParentMovieId = 3, Name = "Mystery" },
                new MovieGenre() { Id = 4, ParentMovieId = 2, Name = "Action" },
                new MovieGenre() { Id = 5, ParentMovieId = 4, Name = "Fantasy" },
                new MovieGenre() { Id = 6, ParentMovieId = 5, Name = "Action" },
                new MovieGenre() { Id = 7, ParentMovieId = 6, Name = "Action" },
                new MovieGenre() { Id = 8, ParentMovieId = 4, Name = "Action" },
                new MovieGenre() { Id = 9, ParentMovieId = 7, Name = "Fantasy" },
                new MovieGenre() { Id = 11, ParentMovieId = 8, Name = "Mystery" },
                new MovieGenre() { Id = 10, ParentMovieId = 9, Name = "Romance" },
                new MovieGenre() { Id = 12, ParentMovieId = 10, Name = "Action" },
                new MovieGenre() { Id = 13, ParentMovieId = 11, Name = "Fantasy" },
                new MovieGenre() { Id = 14, ParentMovieId = 12, Name = "Action" },
                new MovieGenre() { Id = 15, ParentMovieId = 13, Name = "Mystery" },
                new MovieGenre() { Id = 16, ParentMovieId = 12, Name = "Action" },
                new MovieGenre() { Id = 17, ParentMovieId = 2, Name = "Action" },
                new MovieGenre() { Id = 18, ParentMovieId = 13, Name = "Romance" },
                new MovieGenre() { Id = 19, ParentMovieId = 6, Name = "Romance" }

            );
        }
    }
}
