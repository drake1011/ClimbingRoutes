using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimbingRoutes.Database;

namespace ClimbingRoutes.API.Controllers
{
    [ApiController]
    [Route("api/climbers")]
    public class ClimbersController : ControllerBase
    {
        private readonly IClimbingRoutesRepository<Climber> _climberRepository;

        public ClimbersController(IClimbingRoutesRepository<Climber> climberRepository)
        {
            _climberRepository = climberRepository ??
                throw new ArgumentNullException(nameof(climberRepository));
        }

        [HttpGet()]
        public IActionResult GetClimbers()
        {
            var climbers = _climberRepository.All();
            return Ok(climbers);
        }

        [HttpGet("{climberId:int}")]
        public IActionResult GetClimber(int climberId)
        {
            var climber = _climberRepository.FindByKey(climberId);
            if (climber is null) return NotFound();
            return Ok(climber);
        }
    }
}
