using AutoMapper;
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
