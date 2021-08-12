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
                cfg.CreateMap<Department, DepartmentDto>().ForMember(dto => dto.CountAnalitics, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<Employee, EmployeeDto>().ReverseMap();
                cfg.CreateMap<EmployeeRol, EmployeeRolDto>().ReverseMap();

                //cfg.AddProfile<CustomerMappingProfile>();

                cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
            });

            autoMapperConfig.AssertConfigurationIsValid();

            return autoMapperConfig;
        }
    }
}
