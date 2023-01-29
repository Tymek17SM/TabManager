using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.JwtToken
{
    public interface IJwtTokenFactory : IFactory
    {
        JwtSecurityToken GenerateJwtSecurityToken(ApplicationUser applicationUser, IConfiguration configuration);
    }
}
