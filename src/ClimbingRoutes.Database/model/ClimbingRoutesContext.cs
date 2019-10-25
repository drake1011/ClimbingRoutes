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
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Discipline> Crags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Andy", Email = "123@456.com" },
                new User { UserId = 2, Name = "Keith", Email = "789@456.com" },
                new User { UserId = 3, Name = "Zorro", Email = "legend_of@456.com" }
            );

            modelBuilder.Entity<Discipline>().HasData(
                new Discipline { DisciplineId = 1, Description = "Sport" },
                new Discipline { DisciplineId = 2, Description = "Trad" },
                new Discipline { DisciplineId = 3, Description = "Bouldering" }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeId = 1, Description = "7a", DisciplineId = 1 },
                new Grade { GradeId = 2, Description = "7b", DisciplineId = 1 },
                new Grade { GradeId = 3, Description = "7c", DisciplineId = 1 },
                new Grade { GradeId = 4, Description = "E1", DisciplineId = 2 },
                new Grade { GradeId = 5, Description = "f7a", DisciplineId = 3 },
                new Grade { GradeId = 6, Description = "VS", DisciplineId = 2 }
            );

            modelBuilder.Entity<Crag>().HasData(
                new Crag {CragId = 1, Name = "Balmashanner" },
                new Crag {CragId = 2, Name = "Ley Quarry" },
                new Crag {CragId = 3, Name = "Rod Rocks" },
                new Crag {CragId = 4, Name = "Clashrodney" }
            );

            modelBuilder.Entity<Route>().HasData(
                new Route { RouteId = 1,  Name = "Savage Amusement", GradeId = 2, CragId = 1 },
                new Route { RouteId = 2,  Name = "Nirvana", GradeId = 1, CragId = 2 },
                new Route { RouteId = 4,  Name = "Le Bon Vacance", GradeId = 1, CragId = 1 },
                new Route { RouteId = 3,  Name = "Sultan", GradeId = 3, CragId = 3 },
                new Route { RouteId = 5,  Name = "Serpent", GradeId = 6, CragId = 4 }
            );

            modelBuilder.Entity<Style>().HasData(
                new Style { StyleId = 1, Description = "On Sight" },
                new Style { StyleId = 2, Description = "Worked" },
                new Style { StyleId = 3, Description = "Dogged" },
                new Style { StyleId = 4, Description = "Fail" }
            );

            modelBuilder.Entity<Ascent>().HasData(
                new Ascent {
                    AscentId = 1,
                    UserId = 1,
                    RouteId = 1,
                    StyleId = 2,
                    Date = new System.DateTime(year: 2015, month: 7, day: 24)
                },
                new Ascent {
                    AscentId = 2,
                    UserId = 1,
                    RouteId = 4,
                    StyleId = 2,
                    Date = new System.DateTime(year: 2011, month: 7, day: 4)
                },
                new Ascent {
                    AscentId = 3,
                    UserId = 1,
                    RouteId = 2,
                    StyleId = 2,
                    Date = new System.DateTime(year: 2015, month: 8, day: 1)
                },
                new Ascent {
                    AscentId = 4,
                    UserId = 1,
                    RouteId = 3,
                    StyleId = 4,
                    Date = new System.DateTime(year: 2015, month: 9, day: 1)
                }

            );
        }

        public ClimbingRoutesContext(DbContextOptions<ClimbingRoutesContext> options) : base(options)
        {
        }
    }
}