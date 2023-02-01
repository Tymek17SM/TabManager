using Application.Interfaces;
using Application.Interfaces.ReadServices;
using Application.Services;
using Domain.Entities;
using Domain.Factories.DirectoryTabs;
using Domain.Factories.Tabs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(Assembly.Load("Domain"))
            .AddClasses(a => a.AssignableTo<IFactory>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

            services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            services.AddScoped<IResponseCacheService, ResponseCacheService>();

            return services;
        }
    }
}
