using Microsoft.Extensions.DependencyInjection;
using Service.Service;
using Service.ServiceImpl;
using Service.Service.ServiceImpl;

namespace Repository
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddTransient<ISessionService,SessionService>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IDivisionService, DivisionService>();
            services.AddTransient<IDepartmentService, DeparmentService>();
            services.AddTransient<IEmployeeRolService, EmployeeRolService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
