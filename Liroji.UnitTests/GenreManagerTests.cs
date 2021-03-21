using System;
using NUnit.Framework;
using Moq;
using Business;
using Business.Models;
using Microsoft.Extensions.Configuration;

namespace Liroji.UnitTests
{
    [TestFixture]
    public class GenreManagerTests
    {

        [Test]
        public void Create_CreatingGenre_ReturnsNewGenreModelWithAnUniqueId()
        {
            var mockOfIConfiguration = new Mock<IConfiguration>();
            var mock = new Mock<IManager<Genre>>();
            mock.Setup(m => m.Create(new Genre())).Returns(new Genre{
                Id = "Unique Id"
            });
            var manager = new GenreManager(mockOfIConfiguration.Object);

            var genre = new Genre
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "Unit Test",
                Name = "Test Genre",
            };
            var result = manager.Create(genre);

            Assert.IsNotNull(result.Id);
        }

    }
}
