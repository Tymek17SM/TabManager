using Application.Dto;
using MediatR;
using System.Reflection;

namespace WebAPI.Installers
{
    internal sealed class MediatRInstaller : IInstaller
    {
        void IInstaller.InstallServices(IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddMediatR(
                Assembly.Load("WebAPI"), 
                Assembly.Load("Application"), 
                Assembly.Load("Infrastructure")
                );
        }
    }
}
