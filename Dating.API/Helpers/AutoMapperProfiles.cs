using AutoMapper;
using Dating.API.DTOs;
using Dating.API.Extensions;
using Dating.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                src.Photos.FirstOrDefault(x => (bool)x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 
                src.DateOfBirth.Value.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
