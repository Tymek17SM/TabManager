using Application.Interfaces.ReadServices;
using Domain.Interfaces;
using Infrastructure.EF;
using Infrastructure.EF.Context;
using Infrastructure.EF.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Abstractions.Application;
using Shared.Abstractions.Domain;
using Shared.Settings;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMsSql(configuration);

            services.Scan(s => s.FromCallingAssembly()
            .AddClasses(d => d.AssignableTo<IApplicationReadService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.Scan(s => s.FromCallingAssembly()
            .AddClasses(d => d.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());


            services.AddHttpContextAccessor();
            services.AddTransient<IUserResolverService, UserResolverService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
