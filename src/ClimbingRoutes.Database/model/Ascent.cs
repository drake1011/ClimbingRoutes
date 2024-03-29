using System;

namespace ClimbingRoutes.Database.Model
{
    public class Ascent
    {
        public int AscentId { get; set; }
        public int ClimberId { get; set; }
        public int RouteId { get; set; }
        public int StyleId { get; set; }
        public DateTime? Date { get; set; }
    }
}