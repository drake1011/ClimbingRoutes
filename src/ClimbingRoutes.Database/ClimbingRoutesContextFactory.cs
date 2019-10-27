using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;
using ClimbingRoutes.Database.Model;

namespace ClimbingRoutes
{
    public class ClimbingRoutesContextFactory : IDesignTimeDbContextFactory<ClimbingRoutesContext>
    {
        public ClimbingRoutesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClimbingRoutesContext>();
            optionsBuilder.UseSqlServer(@"Server=.\;Database=ClimbingRoutes;Trusted_Connection=True;");

            return new ClimbingRoutesContext(optionsBuilder.Options);
        }
    }
}