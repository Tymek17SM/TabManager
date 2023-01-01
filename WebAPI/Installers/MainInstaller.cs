using Application;
using Application.Dto;
using Application.Interfaces.ReadServices;
using Infrastructure;
using MediatR;
using System.Reflection;

namespace WebAPI.Installers
{
    public class MainInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, ConfigurationManager configurationManager)
        {
            // Add services to the container.

            service.AddApplication(configurationManager);
            service.AddInfrastructure(configurationManager);

            service.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddMvc();
            service.AddMediatR(typeof(Program), typeof(DirectoryTabDto), typeof(Infrastructure.Extensions));
        }
    }
}
