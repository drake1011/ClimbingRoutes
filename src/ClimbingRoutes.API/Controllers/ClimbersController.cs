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
using Microsoft.EntityFrameworkCore; // this must die
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace ClimbingRoutes.API.Controllers
{
    [ApiController]
    [Route("api/climbers")]
    public class ClimbersController : ControllerBase
    {
        private readonly ClimbingRoutesContext _context;
        private readonly DbSet<Climber> _set;
        private readonly IMapper _mapper;

        public ClimbersController(ClimbingRoutesContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _set = context.Set<Climber>();
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<ClimberDto>> GetClimbers()
        {
            var climberEntities = _set.AsNoTracking().ToList();
            return Ok(_mapper.Map<IEnumerable<ClimberDto>>(climberEntities));
        }

        [HttpGet("{climberId}", Name = "GetClimber")]
        [HttpHead]
        public IActionResult GetClimber(int climberId)
        {
            var entity = _set.AsNoTracking().Where(c => c.ClimberId.Equals(climberId)).ToList().FirstOrDefault();

            if (entity is null)
                return NotFound();

            return Ok(_mapper.Map<ClimberDto>(entity));
        }

        [HttpPost]
        public ActionResult<ClimberDto> CreateClimber(ClimberCreationDto climber)
        {
            var entity = _mapper.Map<Climber>(climber);
            _set.Add(entity);
            _context.SaveChanges();
            return CreatedAtRoute(
                "GetClimber",
                new { climberId = entity.ClimberId },
                _mapper.Map<ClimberDto>(entity)
            );
        }
    }
}
