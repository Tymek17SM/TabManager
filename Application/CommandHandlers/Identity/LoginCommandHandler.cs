using Application.Commands.Identity;
using Application.Interfaces.ReadServices;
using Domain.Entities;
using Domain.Factories.ApplicationUsers;
using Domain.Factories.JwtToken;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Identity
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand,string>
    {
        private readonly IApplicationUserReadService _service;
        private readonly IApplicationUserRepository _repository;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IJwtTokenFactory _jwtFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(IApplicationUserReadService service, IApplicationUserRepository repository, 
            IPasswordHasher<ApplicationUser> passwordHasher, IJwtTokenFactory jwtFactory, IConfiguration configuration,
            ILogger<LoginCommandHandler> logger)
        {
            _service = service;
            _repository = repository;
            _passwordHasher = passwordHasher;
            _jwtFactory = jwtFactory;
            _configuration = configuration;
            _logger = logger;
        }

        async Task<string> IRequestHandler<LoginCommand, string>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var (name, password) = request;

            await _service.ExistsByNameAsync(name, true, true);

            var userId = await _service.GetIdByNameAsync(name);

            var user = await _repository.GetByIdAsync(userId);

            var check = user.VerifyPassword(_passwordHasher, password);

            if (check == PasswordVerificationResult.Success)
            {
                var token = _jwtFactory.GenerateJwtSecurityToken(user, _configuration);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return "";
        }
    }
}
