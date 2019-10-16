using Microsoft.EntityFrameworkCore;

namespace ClimbingRoutes
{
    public class ClimbingRoutesContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Ascent> Ascents { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\;Database=ClimbingRoutes;Trusted_Connection=True;");
        }

        // public ClimbingRoutesContext()
        // {
        // }

        public ClimbingRoutesContext(DbContextOptions<ClimbingRoutesContext> options) : base(options)
        {
        }
    }
}