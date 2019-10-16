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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Andy", Email = "123@456.com", Temp = "Delete me" },
            new User { UserId = 2, Name = "Keith", Email = "789@456.com", Temp = "Delete me" }
        );
}

        public ClimbingRoutesContext(DbContextOptions<ClimbingRoutesContext> options) : base(options)
        {
        }
    }
}