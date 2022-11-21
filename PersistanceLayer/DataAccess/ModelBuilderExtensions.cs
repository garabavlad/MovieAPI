using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Persistance;

internal static class ModelBuilderExtensions
{

    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Genres
        var romance = new Genre { Id = 1, Name = "Romance" };
        var action = new Genre { Id = 2, Name = "Action" };
        var mystery = new Genre { Id = 3, Name = "Mystery" };
        var fantasy = new Genre { Id = 4, Name = "Fantasy" };
        var sciFi = new Genre { Id = 5, Name = "Sci-Fi" };

        modelBuilder.Entity<Genre>().HasData(
            romance,
            action, 
            mystery,
            fantasy,
            sciFi
        );


        // Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "Vlad"},
            new User { Id = 2, Username = "John"},
            new User { Id = 3, Username = "Alison"}
            );

        // Movies
        var movie1 = new Movie { Id = 1, Title = "Movie1", };
        var movie2 = new Movie { Id = 2, Title = "Movie2", };
        var movie3 = new Movie { Id = 3, Title = "Movie3", };
        var movie4 = new Movie { Id = 4, Title = "Movie4", };
        var movie5 = new Movie { Id = 5, Title = "Movie5", };

        modelBuilder.Entity<Movie>().HasData(
            movie1,
            movie2,
            movie3,
            movie4,
            movie5
            );

        modelBuilder.Entity<MovieGenre>().HasData(
            new MovieGenre { Id = 1, ParentMovieId = movie1.Id, ParentGenreId = romance.Id},
            new MovieGenre { Id = 2, ParentMovieId = movie1.Id, ParentGenreId = action.Id},
            new MovieGenre { Id = 3, ParentMovieId = movie2.Id, ParentGenreId = sciFi.Id},
            new MovieGenre { Id = 4, ParentMovieId = movie2.Id, ParentGenreId = fantasy.Id},
            new MovieGenre { Id = 5, ParentMovieId = movie3.Id, ParentGenreId = mystery.Id},
            new MovieGenre { Id = 6, ParentMovieId = movie3.Id, ParentGenreId = fantasy.Id},
            new MovieGenre { Id = 7, ParentMovieId = movie4.Id, ParentGenreId = action.Id},
            new MovieGenre { Id = 8, ParentMovieId = movie5.Id, ParentGenreId = romance.Id},
            new MovieGenre { Id = 9, ParentMovieId = movie5.Id, ParentGenreId = fantasy.Id}
            );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, ParentMovieId = 1, ParentUserId = 1, Rating = 4},
            new Review { Id = 2, ParentMovieId = 2, ParentUserId = 1, Rating = 3},
            new Review { Id = 3, ParentMovieId = 3, ParentUserId = 1, Rating = 2},
            new Review { Id = 4, ParentMovieId = 5, ParentUserId = 1, Rating = 3},
            new Review { Id = 5, ParentMovieId = 1, ParentUserId = 2, Rating = 5},
            new Review { Id = 6, ParentMovieId = 2, ParentUserId = 2, Rating = 4},
            new Review { Id = 7, ParentMovieId = 3, ParentUserId = 2, Rating = 1},
            new Review { Id = 8, ParentMovieId = 4, ParentUserId = 2, Rating = 2},
            new Review { Id = 9, ParentMovieId = 5, ParentUserId = 2, Rating = 4},
            new Review { Id = 11, ParentMovieId = 1, ParentUserId = 3, Rating = 4},
            new Review { Id = 15, ParentMovieId = 3, ParentUserId = 3, Rating = 4},
            new Review { Id = 16, ParentMovieId = 4, ParentUserId = 3, Rating = 3}
            );

    }
}
