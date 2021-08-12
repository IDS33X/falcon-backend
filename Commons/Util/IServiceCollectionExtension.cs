using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Mappings;

namespace Util
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddUtilServices(this IServiceCollection services)
        {
            var mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            services.AddSingleton<IMapper>(mapper);
            return services;
        }
    }
}
