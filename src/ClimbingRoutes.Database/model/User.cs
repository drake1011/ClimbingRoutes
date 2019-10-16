
using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Temp {get; set; }
        public string Temp2 {get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}
