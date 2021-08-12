using Microsoft.Extensions.DependencyInjection;
using Util;

namespace FalconApi
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesFromOtherModules(this IServiceCollection services)
        {
            services.AddUtilServices();
            return services;
        }
    }
}
