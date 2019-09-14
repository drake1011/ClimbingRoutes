
using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }

        public Grade Grade { get; set; }
        public int GradeId { get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}
