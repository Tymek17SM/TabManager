using Infrastructure.EF.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI.Installers
{
    public class IdentityInstaller : IInstaller
    {
        void IInstaller.InstallServices(IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, //default tez jest true
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configurationManager["JWT:Issuer"],
                    ValidAudience = configurationManager["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["JWT:SecretKey"]))
                };
            });
        }
    }
}
