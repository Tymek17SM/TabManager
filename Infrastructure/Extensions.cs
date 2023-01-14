using Application.Interfaces.ReadServices;
using Domain.Interfaces;
using Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Application;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Extensions 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMsSql(configuration);

            service.Scan(s => s.FromCallingAssembly()
            .AddClasses(d => d.AssignableTo<IApplicationReadService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            service.Scan(s => s.FromCallingAssembly()
            .AddClasses(d => d.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
