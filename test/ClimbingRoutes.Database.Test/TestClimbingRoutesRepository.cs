using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClimbingRoutes.Database.Test
{
    public class TestClimbingRoutesRepository
    {
        [Fact]
        public void TestAllMethod()
        {
            // Arrange
            var repo = new ClimbingRoutesRepository<Climber>(TestHelpers.GetNewContext());
            var expected = 3;

            // Act
            var usersCount = repo.All().Count();

            // Assert
            Assert.Equal(expected, usersCount);
        }

        [Fact]
        public void TestDelete()
        {
            // Arrange
            var repo = new ClimbingRoutesRepository<Ascent>(TestHelpers.GetNewContext());
            var initalExpected = 4;
            var finalExpected = 3;

            // Act
            var initial = repo.All().Count();
            repo.Delete(1);
            var final = repo.All().Count();

            // Assert
            Assert.Equal(initalExpected, initial);
            Assert.Equal(finalExpected, finalExpected);
        }

        [Fact]
        public void TestInsert()
        {
            // Arrange
            var repo = new ClimbingRoutesRepository<Ascent>(TestHelpers.GetNewContext());
            var initalExpected = 4;
            var finalExpected = 5;
            var ascent = new Ascent(){
                    UserId = 2,
                    RouteId = 1,
                    StyleId = 2,
                    Date = new System.DateTime(year: 2019, month: 10, day: 18)
                };

            // Act
            var initial = repo.All().Count();
            repo.Insert(ascent);
            var final = repo.All().Count();

            // Assert
            Assert.Equal(initalExpected, initial);
            Assert.Equal(finalExpected, finalExpected);
        }

        [Fact]
        public void TestUpdate()
        {
            // Arrange
            var repo = new ClimbingRoutesRepository<Climber>(TestHelpers.GetNewContext());
            string expected = "Zaphod";

            // Act
            var user = repo.All().FirstOrDefault();
            var initial = user.Name;
            user.Name = expected;
            repo.Update(user);
            var actual = repo.All().FirstOrDefault().Name;

            // Assert
            Assert.NotEqual(expected, initial); // Make sure the names are not equal at the start
            Assert.Equal(expected, actual);
        }
    }
}