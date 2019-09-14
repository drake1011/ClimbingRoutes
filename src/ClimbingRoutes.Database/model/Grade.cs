
using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Description { get; set; }

        public IList<Route> Routes { get; set; }
    }
}