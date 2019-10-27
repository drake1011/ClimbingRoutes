using System.Collections.Generic;

namespace ClimbingRoutes.Database.Model
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Description { get; set; }

        public IList<Grade> Grades { get; set; }
    }
}