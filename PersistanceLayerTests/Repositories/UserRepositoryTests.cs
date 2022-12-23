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
    public class UserRepositoryTests
    {
        private Mock<MovieDatabaseContext> _mockContext;
        private Mock<DbSet<User>> _mockSet;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<MovieDatabaseContext>(new DbContextOptions<MovieDatabaseContext>());
            _mockSet = new Mock<DbSet<User>>();
        }

        [Test]
        public void Given_users_with_reviews_return_children()
        {
            // Arrange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username= "Test1",
                    Reviews= new List<Review> {}
                },

                new User
                {
                    Id = 2,
                    Username= "Test2",
                    Reviews= new List<Review>
                    {
                        new Review
                        {
                            Id= 3,
                            Rating = 1
                        }
                    }
                },
            }.AsQueryable();

            _mockSet.As<IQueryable<User>>().Setup(x => x.Provider).Returns(users.Provider);
            _mockSet.As<IQueryable<User>>().Setup(x => x.Expression).Returns(users.Expression);
            _mockSet.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(users.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            _mockContext.Setup(x => x.Users).Returns(_mockSet.Object);

            var userRepo = new UserRepository(_mockContext.Object);

            // Act
            var allUsers = userRepo.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, allUsers.Count); // returns all users
            Assert.NotNull(allUsers.First(u => u.Id == 2)
                .Reviews.FirstOrDefault(r => r.Id == 3)); // user 2 has a review with id 3
        }
    }
}
