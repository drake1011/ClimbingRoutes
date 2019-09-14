using System;

namespace ClimbingRoutes
{
    public class Ascent
    {
        public int AscentId { get; set; }
        public int UserId { get; set; }
        public int RouteId { get; set; }
        public int StyleId { get; set; }
        public DateTime Date { get; set; }
    }
}