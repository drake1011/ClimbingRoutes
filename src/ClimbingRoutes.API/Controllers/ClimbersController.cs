using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimbingRoutes.Database;
using ClimbingRoutes.API.DTOs;
using ClimbingRoutes.API.Helpers;
using ClimbingRoutes.Database.Model;
using AutoMapper;

namespace ClimbingRoutes.API.Controllers
{
    [ApiController]
    [Route("api/climbers")]
    public class ClimbersController : ControllerBase
    {
        private readonly IClimbingRoutesRepository<Climber> _climberRepository;
        private readonly IMapper _mapper;

        public ClimbersController(IClimbingRoutesRepository<Climber> climberRepository, IMapper mapper)
        {
            _climberRepository = climberRepository ??
                throw new ArgumentNullException(nameof(climberRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ClimberDto>> GetClimbers()
        {
            var climberEntities = _climberRepository.All();
            return Ok(_mapper.Map<IEnumerable<ClimberDto>>(climberEntities));
        }

        [HttpGet("{climberId:int}")]
        public IActionResult GetClimber(int climberId)
        {
            var entity = _climberRepository.FindByKey(climberId);
            
            if (entity is null)
                return NotFound();
            
            return Ok(_mapper.Map<ClimberDto>(entity));
        }
    }
}
