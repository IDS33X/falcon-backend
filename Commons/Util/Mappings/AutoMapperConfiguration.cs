using AutoMapper;
using Domain.Models;
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
                cfg.CreateMap<Division, DivisionDto>().ForMember(dto => dto.CountDepartments, opt => opt.Ignore())
                    .ForMember(dto => dto.UserId, opt => opt.MapFrom(domain => domain.UserProfileId))
                    .ForMember(dto => dto.User, opt => opt.MapFrom(domain => domain.UserProfile)).ReverseMap();
                cfg.CreateMap<Department, DepartmentDto>().ForMember(dto => dto.CountAnalytics, opt => opt.Ignore()).ReverseMap();
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

                cfg.CreateMap<Control, ControlDto>().ForMember(dto => dto.AutomationLevel , opt => opt.MapFrom(ent => ent.AutomationLevel.Title))
                   .ForMember(dto => dto.ControlState, opt => opt.MapFrom(ent => ent.ControlState.Title))
                   .ForMember(dto => dto.ControlType, opt => opt.MapFrom(ent => ent.ControlType.Title))
                   .ReverseMap();

                cfg.CreateMap<MAutomationLevel, MAutomationLevelDto>().ReverseMap();
                cfg.CreateMap<MControlState, MControlStateDto>().ReverseMap();
                cfg.CreateMap<MControlType, MControlTypeDto>().ReverseMap();
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
