﻿namespace WebAPI.Installers
{
    public interface IInstaller
    {
        public void InstallServices(IServiceCollection services, ConfigurationManager configurationManager);
    }
}
