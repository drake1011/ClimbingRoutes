
using System.Collections.Generic;

namespace ClimbingRoutes.Database.Model
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }

        public Grade Grade { get; set; }
        public int GradeId { get; set; }

        public Crag Crag { get; set; }
        public int CragId { get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}
