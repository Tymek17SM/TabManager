using Infrastructure.EF.Context;
using Infrastructure.EF.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    internal static class Extensions
    {
        internal static IServiceCollection AddMsSql(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSettings<MsSqlOptions>("MsSql");
            services.AddDbContext<ReadDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(options.ConnectionString));
            
            return services;
        }
    }
}
