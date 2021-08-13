using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Service;
using Service.ServiceImpl;

namespace Repository
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddTransient<ISessionService,SessionService>();
            return services;
        }
    }
}
