using Application;
using Application.Dto;
using Application.Interfaces.ReadServices;
using Infrastructure;
using MediatR;
using System.Reflection;

namespace WebAPI.Installers
{
    internal sealed class MainInstaller : IInstaller
    {
        void IInstaller.InstallServices(IServiceCollection services, ConfigurationManager configurationManager)
        {
            // Add services to the container.
            //------------------------------

            services.AddApplication();
            services.AddInfrastructure(configurationManager);

            services.AddMetrics();

            services.AddControllers();

            services.AddAuthorization();
        }
    }
}
