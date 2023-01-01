using Application.Interfaces.ReadServices;
using Domain.Factories.DirectoryTabs;
using Domain.Factories.Tabs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITabFactory, TabFactory>();
            services.AddSingleton<IDirectoryTabFactory, DirectoryTabFactory>();
            //services.Scan(s => s.FromAssemblyOf<IApplicationReadService>()
            //.AddClasses(c => c.AssignableTo<IApplicationReadService>())
            //.AsImplementedInterfaces()
            //.WithScopedLifetime());

            return services;
        }
    }
}
