using System.Collections.Generic;
using APIMovieExample.Controllers;
using APIMovieExample.DataLayer;
using APIMovieExample.QueryParameters;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieAPI.Models;
using NUnit.Framework;

namespace APIMovieTest
{
    public class AControllerTest
    {
        public AControllerTest() { }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var movieMockSet = new Mock<DbSet<Movie>>();
            var reviewMockSet = new Mock<DbSet<Review>>();
            var userMockSet = new Mock<DbSet<User>>();
            //var movieGenreMockSet = new Mock<DbSet<MovieGenreModel>>(); // to set up

            var mockContext = new Mock<MovieDatabaseContext>();
            mockContext.Setup(m => m.Movies).Returns(movieMockSet.Object);
            mockContext.Setup(m => m.Reviews).Returns(reviewMockSet.Object);
            mockContext.Setup(m => m.Users).Returns(userMockSet.Object);

            var controller = new AController(mockContext.Object);

            // just checking if we are retrieving correctly a movie
            var taskResult = controller.SearchForMovie(new MovieSearchQueryParameter() { Title = "Movie1" });
            var movie1inList = taskResult.Result as IEnumerable<Movie>;

            Assert.AreEqual(1, movie1inList);
            //movieMockSet.Verify(M => M.);

        }
    }
}