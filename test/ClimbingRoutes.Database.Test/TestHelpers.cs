using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ClimbingRoutes.Database.Test
{
    public static class TestHelpers
    {
        public static ClimbingRoutesContext GetNewContext()
        {
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };

            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<ClimbingRoutesContext>()
                .UseSqlite(connection)
                .Options;

            var context = new ClimbingRoutesContext(options);

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            return context;
        }
    }
}