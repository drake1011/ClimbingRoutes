using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class Climber
    {
        public int ClimberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}
