using Application.Cache;
using Microsoft.Extensions.Configuration;
using Shared.Cache;

namespace WebAPI.Installers
{
    internal sealed class CacheInstaller : IInstaller
    {
        void IInstaller.InstallServices(IServiceCollection services, ConfigurationManager configurationManager)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configurationManager.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
        }
    }
}
