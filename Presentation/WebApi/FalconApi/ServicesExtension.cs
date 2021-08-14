using Microsoft.Extensions.DependencyInjection;
using Util;
using Repository;
using Service;

namespace FalconApi
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesFromOtherModules(this IServiceCollection services)
        {
            services.AddUtilServices();
            services.AddRepositoryServices();
            services.AddServiceServices();
            return services;
        }
    }
}
