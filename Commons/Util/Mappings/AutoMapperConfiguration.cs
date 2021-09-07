using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfig()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Area, AreaDto>().ForMember(dto => dto.CountDivisions, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<Division, DivisionDto>().ForMember(dto => dto.CountDepartments, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<Department, DepartmentDto>().ForMember(dto => dto.CountAnalytics, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<UserProfile, UserDto>().ForMember(dto => dto.Password, opt => opt.MapFrom(des => des.User.Password))
                    .ForMember(dto => dto.Username, opt => opt.MapFrom(des => des.User.Username))
                    .ForMember(dto => dto.UserId, opt => opt.MapFrom(des => des.Id)).ReverseMap();
                cfg.CreateMap<MRole, MRoleDto>().ReverseMap();

                //cfg.AddProfile<CustomerMappingProfile>();

                cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
            });

            autoMapperConfig.AssertConfigurationIsValid();

            return autoMapperConfig;
        }
    }
}
