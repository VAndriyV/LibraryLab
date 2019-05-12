using DataEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryLab.Configurations
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddLibraryContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options => options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));

            return services;
        }
    }
}
