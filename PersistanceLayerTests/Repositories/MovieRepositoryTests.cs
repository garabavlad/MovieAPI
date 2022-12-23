using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieAPI.Models;
using MovieAPI.Persistance;
using NUnit.Framework;

namespace UnitTest.PersistanceLayer.Repositories
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        private Mock<MovieDatabaseContext> _mockContext;
        private Mock<DbSet<Movie>> _mockSet;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<MovieDatabaseContext>(new DbContextOptions<MovieDatabaseContext>());
            _mockSet = new Mock<DbSet<Movie>>();
        }

        [Test]
        public void Given_movies_with_reviews_and_genres_return_all_children()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title= "Test1",
                },
                new Movie
                {
                    Id = 2,
                    Title= "Test2",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Id = 3,
                            Rating = 3
                        }
                    },
                    GenreMovie = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Id = 4,
                            Genre = new Genre
                            {
                                Id = 5,
                                Name = "Action",
                            }
                        }
                    }
                }
            }.AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Movies).Returns(_mockSet.Object);

            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            var allMovies = movieRepo.GetAll().ToList();

            // Assert
            Assert.That(allMovies.Count, Is.EqualTo(2)); // returns all users
            Assert.NotNull(allMovies.First(u => u.Id == 2)
                .Reviews.FirstOrDefault(r => r.Id == 3)); // movie with id 2 has a review with id 3

            Assert.NotNull(allMovies.First(u => u.Id == 2)
                .GenreMovie.FirstOrDefault(g => g.Id == 4 && g.Genre?.Id == 5)); // movie with id 2 has a genre movie with id 4 & a genre with id 5 (as per input);
        }
    }
}
