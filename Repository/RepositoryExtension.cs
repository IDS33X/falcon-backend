using Microsoft.Extensions.DependencyInjection;
using Repository.UnitOfWork;
using Repository.Context;

namespace Repository
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddDbContext<FalconDBContext>();
            services.AddTransient<IUnitOfWork,UnitOfWorkImpl.UnitOfWork>();
            return services;
        }
    }
}
