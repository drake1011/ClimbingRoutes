using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimbingRoutes.Database;
using ClimbingRoutes.API.DTOs;
using ClimbingRoutes.API.Helpers;
using ClimbingRoutes.Database.Model;

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
        public ActionResult<IEnumerable<ClimberDto>> GetClimbers()
        {
            var climberEntities = _climberRepository.All();

            var climbers = new List<ClimberDto>();

            foreach (var entity in climberEntities)
            {
                climbers.Add(new ClimberDto()
                {
                    Id = entity.ClimberId,
                    Name = $"{entity.FirstName} {entity.LastName}",
                    Age = entity.DateOfBirth.GetCurrentAge()
                }); ;
            }


            return Ok(climbers);
        }

        [HttpGet("{climberId:int}")]
        public IActionResult GetClimber(int climberId)
        {
            var climber = _climberRepository.FindByKey(climberId);
            
            if (climber is null)
                return NotFound();
            
            return Ok(climber);
        }
    }
}
