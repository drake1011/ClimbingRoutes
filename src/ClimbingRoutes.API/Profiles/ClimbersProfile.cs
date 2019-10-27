using AutoMapper;
using ClimbingRoutes.API.DTOs;
using ClimbingRoutes.API.Helpers;
using ClimbingRoutes.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingRoutes.API.Profiles
{
    public class ClimbersProfile : Profile
    {
        public ClimbersProfile()
        {
            CreateMap<Climber, ClimberDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ClimberId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
