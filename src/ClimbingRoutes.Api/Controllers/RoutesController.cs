using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClimbingRoutes.Api.DataTransferObjects;

namespace ClimbingRoutes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ClimbingRoutesContext _context;
        private readonly ILogger<ClimbingRoutesContext> _logger;

        public RoutesController(ClimbingRoutesContext context)
        {
            _context = context;

            if (context.Routes.Count().Equals(0))
            {

            }
        }



        [HttpGet]
        public IEnumerable<RouteDTO> GetRouteNames()
        {
            return new List<RouteDTO> {
                new RouteDTO() { Name = "Savage Amusement" },
                new RouteDTO() { Name = "Nirvana" },
                new RouteDTO() { Name = "Spandex Ballet" }
            };
        }
    }
}
