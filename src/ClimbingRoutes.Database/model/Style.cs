using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class Style
    {
        public int StyleId { get; set; }
        public string Description { get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}