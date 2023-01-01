using System.Linq;
using System.Reflection;

namespace WebAPI.Installers
{
    internal static class InstallerExtension
    {
        internal static void InstallServicesInAssembly(this IServiceCollection services, ConfigurationManager configurationManager) 
        {
            //var test1 = Assembly.GetExecutingAssembly();

            //var test2 = typeof(Program).Assembly;

            var installers =
                Assembly.GetExecutingAssembly()
                .ExportedTypes
                .Where(x => x.IsAssignableTo(typeof(IInstaller)) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configurationManager));
        }
    }
}
