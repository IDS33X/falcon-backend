using AutoMapper;
using Domain.Models;
using Util.Dtos;
using Util.Dtos.AutomationLevelDtos;
using Util.Dtos.ControlDtos;
using Util.Dtos.ControlStateDtos;
using Util.Dtos.ControlTypeDtos;
using Util.Dtos.DepartmentDtos;
using Util.Dtos.DivisionDtos;
using Util.Mappings.Profiles;

namespace Util.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfig()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AreaProfile>();
                cfg.AddProfile<ControlProfile>();
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<DivisionProfile>();
                cfg.AddProfile<ControlStateProfile>();
                cfg.AddProfile<ControlTypeProfile>();
                cfg.AddProfile<AutomationLevelProfile>();

                //cfg.CreateMap<Area, AreaReadDto>().ForMember(dto => dto.CountDivisions, opt => opt.Ignore()).ReverseMap();
                //cfg.CreateMap<Division, DivisionReadDto>().ForMember(dto => dto.CountDepartments, opt => opt.Ignore())
                //    .ForMember(dto => dto.UserId, opt => opt.MapFrom(domain => domain.UserProfileId))
                //    .ForMember(dto => dto.User, opt => opt.MapFrom(domain => domain.UserProfile)).ReverseMap();
                //cfg.CreateMap<Department, DepartmentReadDto>().ForMember(dto => dto.CountAnalytics, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<UserProfile, UserDto>().ForMember(dto => dto.Password, opt => opt.MapFrom(des => des.User.Password))
                    .ForMember(dto => dto.Username, opt => opt.MapFrom(des => des.User.Username))
                    .ForMember(dto => dto.Id, opt => opt.MapFrom(des => des.Id))
                    .ForMember(dto => dto.RoleId, opt => opt.MapFrom(domain => domain.User.UserRoleId))
                    .ForMember(dto => dto.Role, opt => opt.MapFrom(domain => domain.User.UserRole)).ReverseMap();
                cfg.CreateMap<MRole, MRoleDto>().ReverseMap();
                cfg.CreateMap<RiskCategory, RiskCategoryDto>().ReverseMap();
                cfg.CreateMap<RiskImpact, RiskImpactDto>()
                   .ForMember(dto => dto.Title, opt => opt.MapFrom(domain => domain.ImpactType.Title))
                   .ForMember(dto => dto.Description, opt => opt.MapFrom(domain => domain.ImpactType.Description))
                   .ReverseMap();
                cfg.CreateMap<Risk, RiskDto>().ReverseMap();

                //cfg.CreateMap<Control, ControlReadDto>().ForMember(dto => dto.AutomationLevel , opt => opt.MapFrom(ent => ent.AutomationLevel.Title))
                //   .ForMember(dto => dto.ControlState, opt => opt.MapFrom(ent => ent.ControlState.Title))
                //   .ForMember(dto => dto.ControlType, opt => opt.MapFrom(ent => ent.ControlType.Title))
                //   .ReverseMap();

                //cfg.CreateMap<MAutomationLevel, MAutomationLevelReadDto>().ReverseMap();
                //cfg.CreateMap<MControlState, MControlStateReadDto>().ReverseMap();
                //cfg.CreateMap<MControlType, MControlTypeReadDto>().ReverseMap();
                cfg.CreateMap<RiskControl, RiskControlDto>().ReverseMap();
                cfg.CreateMap<UserControl, UserControlDto>().ReverseMap();

                //cfg.AddProfile<CustomerMappingProfile>();

                cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
            });

            //autoMapperConfig.AssertConfigurationIsValid();

            return autoMapperConfig;
        }
    }
}
