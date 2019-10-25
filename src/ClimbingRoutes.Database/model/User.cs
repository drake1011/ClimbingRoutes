using System.Collections.Generic;

namespace ClimbingRoutes
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IList<Ascent> Ascents { get; set; }
        public IList<User> Partners { get; set; }
    }
}
