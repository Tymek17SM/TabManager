using System.Linq;
using System.Reflection;

namespace WebAPI.Installers
{
    internal static class InstallerExtension
    {
        internal static void InstallServicesInAssembly(this IServiceCollection services, ConfigurationManager configurationManager) 
        {
            var installers =
                Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(x => x.IsAssignableTo(typeof(IInstaller)) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configurationManager));
        }
    }
}
