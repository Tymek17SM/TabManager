namespace WebAPI.Installers
{
    internal interface IInstaller
    {
        internal protected void InstallServices(IServiceCollection services, ConfigurationManager configurationManager);
    }
}
