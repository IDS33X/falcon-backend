using AutoMapper;
using Domain.Models;
using Util.Dtos;
using Util.Dtos.MRole;
using Util.Dtos.Risk;
using Util.Dtos.RiskControl;
using Util.Dtos.RiskImpact;
using Util.Dtos.User;
using Util.Mappings.Profiles;

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

                cfg.CreateMap<Control, ControlDto>().ForMember(dto => dto.AutomationLevel , opt => opt.MapFrom(ent => ent.AutomationLevel.Title))
                   .ForMember(dto => dto.ControlState, opt => opt.MapFrom(ent => ent.ControlState.Title))
                   .ForMember(dto => dto.ControlType, opt => opt.MapFrom(ent => ent.ControlType.Title))
                   .ReverseMap();

                cfg.CreateMap<MAutomationLevel, MAutomationLevelDto>().ReverseMap();
                cfg.CreateMap<MControlState, MControlStateDto>().ReverseMap();
                cfg.CreateMap<MControlType, MControlTypeDto>().ReverseMap();

                cfg.AddProfile<RiskCategoryProfile>();
                cfg.AddProfile<UserMapperProfile>();
                cfg.AddProfile<UserControlProfile>();
                cfg.AddProfile<RiskControlProfile>();
                cfg.AddProfile<RiskProfile>();
                cfg.AddProfile<MRoleProfile>();
                cfg.AddProfile<RiskImpactProfile>();

                cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
            });

            autoMapperConfig.AssertConfigurationIsValid();

            return autoMapperConfig;
        }
    }
}
