
using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Description { get; set; }
        public int DisciplineId { get; set; }

        public IList<Route> Routes { get; set; }
    }
}