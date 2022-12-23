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
    public class GericRepositoryTests
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
        public void Given_Add_calls_DbSet_Add()
        {
            // Arrange
            var movie = new Movie
            {
                Id = 1,
                Title = "Test1",
            };
            var movies = new List<Movie>().AsQueryable(); // empty list

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.Add(movie);

            // Assert
            _mockSet.Verify(x => x.Add(movie), Times.Once);
        }

        [Test]
        public void Given_AddRange_calls_DbSet_AddRng()
        {
            // Arrange
            var newMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Test1",
                },
                new Movie
                { 
                    Id = 2,
                    Title= "Test2",
                }
            };


            var movies = new List<Movie> { }.AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.AddRange(newMovies);

            // Assert
            _mockSet.Verify(x => x.AddRange(newMovies), Times.Once);
        }

        [Test]
        public void Given_Update_calls_DbSet_Upd()
        {
            // Arrange
            var movie = new Movie
            {
                Id = 1,
                Title = "new title",
            };
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Existing Title",
                }
            }
            .AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.Update(movie);

            // Assert
            _mockSet.Verify(x => x.Update(movie), Times.Once);
        }

        [Test]
        public void Given_Find_applies_expression()
        {
            // Arrange
            var movie = new Movie
            {
                Id = 1,
                Title = "new title",
            };
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Existing Title",
                }
            }
            .AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.Update(movie);

            // Assert
            _mockSet.Verify(x => x.Update(movie), Times.Once);
        }

        [Test]
        public void Given_GetById_returns_right_entity()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Title",
                },
                new Movie
                {
                    Id = 2,
                    Title = "Another Title",
                },
            }
            .AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockSet.Setup(x => x.Find(2))
                .Returns(movies.FirstOrDefault(m => m.Id == 2));

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            var foundMovie = movieRepo.GetById(2);

            // Assert
            Assert.That(foundMovie, Is.Not.Null);
            Assert.That(foundMovie.Id, Is.EqualTo(2));
        }

        [Test]
        public void Given_Remove_calls_DbSet_Remove()
        {
            // Arrange
            var movie = new Movie
            {
                Id = 1,
                Title = "Test1",
            };
            var movies = new List<Movie>().AsQueryable(); // empty list

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.Remove(movie);

            // Assert
            _mockSet.Verify(x => x.Remove(movie), Times.Once);
        }

        [Test]
        public void Given_RemoveRange_calls_DbSet_RemoveRng()
        {
            // Arrange
            var toRemoveMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Test1",
                },
                new Movie
                {
                    Id = 2,
                    Title= "Test2",
                }
            };


            var movies = new List<Movie> { }.AsQueryable();

            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Provider).Returns(movies.Provider);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.Expression).Returns(movies.Expression);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.ElementType).Returns(movies.ElementType);
            _mockSet.As<IQueryable<Movie>>().Setup(x => x.GetEnumerator()).Returns(movies.GetEnumerator());

            _mockContext.Setup(x => x.Set<Movie>()).Returns(_mockSet.Object);
            var movieRepo = new MovieRepository(_mockContext.Object);

            // Act
            movieRepo.RemoveRange(toRemoveMovies);

            // Assert
            _mockSet.Verify(x => x.RemoveRange(toRemoveMovies), Times.Once);
        }
    }
}
