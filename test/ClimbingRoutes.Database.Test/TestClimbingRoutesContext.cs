using System;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClimbingRoutes.Database.Test
{
    public class TestClimbingRoutesContext
    {
        [Fact]
        public void TrivialTest()
        {
            // Arrange
            var user = new User() { Name = "Andy", Email = "123@456.com" };

            // Act
            user.Name = "Changed";

            //Assert
            Assert.Equal("Changed", user.Name);
        }

        [Fact]
        public void TestTheSeededUserData()
        {
            // Arrange
            int numUsers;
            int expected = 3;

            // Act
            using (var context = TestHelpers.GetNewContext())
            {
                numUsers = context.Users.Count();
            }

            // Assert
            Assert.Equal(expected, numUsers);
        }

                [Fact]
        public void TestTheSeededGradeData()
        {
            // Arrange
            int numGrades;
            int expected = 5;

            // Act
            using (var context = TestHelpers.GetNewContext())
            {
                numGrades = context.Grades.Count();
            }

            // Assert
            Assert.Equal(expected, numGrades);
        }

                [Fact]
        public void TestTheSeededAscentData()
        {
            // Arrange
            int numAscents;
            int expected = 4;

            // Act
            using (var context = TestHelpers.GetNewContext())
            {
                numAscents = context.Ascents.Count();
            }

            // Assert
            Assert.Equal(expected, numAscents);
        }

                [Fact]
        public void TestTheSeededRouteData()
        {
            // Arrange
            int numRoutes;
            int expected = 4;

            // Act
            using (var context = TestHelpers.GetNewContext())
            {
                numRoutes = context.Routes.Count();
            }

            // Assert
            Assert.Equal(expected, numRoutes);
        }

                [Fact]
        public void TestTheSeededStyleData()
        {
            // Arrange
            int numStyles;
            int expected = 4;

            // Act
            using (var context = TestHelpers.GetNewContext())
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                numStyles = context.Styles.Count();
            }

            // Assert
            Assert.Equal(expected, numStyles);
        }

        [Fact]
        public void BasicDatabaseTest()
        {
            // Arrange
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };

            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<ClimbingRoutesContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ClimbingRoutesContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Users.Add(new User() { Name = "Matthew" });
                context.Users.Add(new User() { Name = "Mark" });
                context.Users.Add(new User() { Name = "Luke" });
                context.Users.Add(new User() { Name = "John" });

                context.SaveChanges();
            }

            int numUser;

            // Three are added in the seed data. For a total of 7...
            int expected = 7;

            using (var context = new ClimbingRoutesContext(options))
            {
                // Act
                numUser = context.Users.ToList().Count;
            }

            // Assert
            Assert.Equal(numUser, expected);
        }
    }
}
