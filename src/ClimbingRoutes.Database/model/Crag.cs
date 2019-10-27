using System.Collections.Generic;

namespace ClimbingRoutes.Database.Model
{
    public class Crag
    {
        public int CragId { get; set; }
        public string Name { get; set; }

        public IList<Route> Routes { get; set; }
    }
}
