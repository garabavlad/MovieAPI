using NUnit.Framework;
using MovieAPI.Models;
using System;

namespace ModelsTests.Models;

[TestFixture]
public class ReviewTests
{
    [SetUp]
    public void Setup()
    {

    }

    [TearDown]
    public void TearDown() { }

    [Test]
    public void ReviewContructor_On_Wrong_Input_ThrowsException()
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<NotSupportedException>(delegate { var exceptionRaisingContructor = new Review(0, null, null); });
    }
}
