using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository;
using Repository.UnitOfWork;
using Repository.UnitOfWorkImpl;
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
