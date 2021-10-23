using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.DivisionDtos;

namespace Util.Mappings.Profiles
{
    public class DivisionProfile: Profile
    {
        public DivisionProfile()
        {
            CreateMap<Division, DivisionReadDto>().ForMember(dto => dto.CountDepartments, opt => opt.Ignore())
                    .ForMember(dto => dto.UserId, opt => opt.MapFrom(domain => domain.UserProfileId))
                    .ForMember(dto => dto.User, opt => opt.MapFrom(domain => domain.UserProfile)).ReverseMap();
            CreateMap<DivisionCreateDto, Division>();
            CreateMap<DivisionUpdateDto, Division>().ForMember(ent => ent.UserProfileId, opt => opt.MapFrom(dto => dto.UserId));

        }
    }
}
