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

            CreateMap<DivisionCreateDto, Division>().ForMember(ent => ent.UserProfileId, opt => opt.MapFrom(dto => dto.UserId))
                                                    .ForMember(d => d.Area, opt => opt.Ignore())
                                                    .ForMember(d => d.UserProfile, opt => opt.Ignore())
                                                    .ForMember(d => d.Departments, opt => opt.Ignore())
                                                    .ForMember(d => d.Id, opt => opt.Ignore())
                                                    .ForMember(d => d.Enabled, opt => opt.Ignore())
                                                    .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                                                    ;
            CreateMap<DivisionUpdateDto, Division>().ForMember(ent => ent.UserProfileId, opt => opt.MapFrom(dto => dto.UserId))
                                                    .ForMember(d => d.AreaId, opt => opt.Ignore())
                                                    .ForMember(d => d.Area, opt => opt.Ignore())
                                                    .ForMember(d => d.UserProfile, opt => opt.Ignore())
                                                    .ForMember(d => d.Departments, opt => opt.Ignore())
                                                    .ForMember(d => d.Enabled, opt => opt.Ignore())
                                                    .ForMember(d => d.CreatedDate, opt => opt.Ignore());

        }
    }
}
