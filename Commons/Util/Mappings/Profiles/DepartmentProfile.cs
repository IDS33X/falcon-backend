using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.DepartmentDtos;

namespace Util.Mappings.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentReadDto>().ForMember(dto => dto.CountAnalytics, opt => opt.Ignore()).ReverseMap();

            CreateMap<DepartmentCreateDto, Department>().ForMember(d => d.Division, opt => opt.Ignore())
                                                        .ForMember(d => d.UserProfiles, opt => opt.Ignore())
                                                        .ForMember(d => d.RiskCategories, opt => opt.Ignore())
                                                        .ForMember(d => d.Id, opt => opt.Ignore())
                                                        .ForMember(d => d.Enabled, opt => opt.Ignore())
                                                        .ForMember(d => d.CreatedDate, opt => opt.Ignore());

            CreateMap<DepartmentUpdateDto, Department>().ForMember(d => d.DivisionId, opt => opt.Ignore())
                                                        .ForMember(d => d.Division, opt => opt.Ignore())
                                                        .ForMember(d => d.UserProfiles, opt => opt.Ignore())
                                                        .ForMember(d => d.RiskCategories, opt => opt.Ignore())
                                                        .ForMember(d => d.Enabled, opt => opt.Ignore())
                                                        .ForMember(d => d.CreatedDate, opt => opt.Ignore());
        }
    }
}
