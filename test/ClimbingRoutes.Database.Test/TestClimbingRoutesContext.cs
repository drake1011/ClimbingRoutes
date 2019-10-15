using System;
using Xunit;
using ClimbingRoutes.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClimbingRoutes.Database.Test
{
    public class TestClimbingRoutesContext
    {
        // [Fact]
        // public void TrivialTest()
        // {
        //     // Arrange
        //     var user = new User() { Name = "Andy", Email = "123@456.com" };

        //     // Act
        //     user.Name = "Changed";

        //     //Assert
        //     Assert.Equal("Changed", user.Name);
        // }

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

                context.Users.Add(new User()
                {
                    Name = "Matthew"
                });

                context.Users.Add(new User()
                {
                    Name = "Mark"
                });

                context.Users.Add(new User()
                {
                    Name = "Luke"
                });

                context.Users.Add(new User()
                {
                    Name = "John"
                });

                context.SaveChanges();
            }

            int numUser;
            int expected = 4;

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
