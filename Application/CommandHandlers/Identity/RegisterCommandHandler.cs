using Application.Commands.Identity;
using Application.Interfaces.ReadServices;
using Domain.Entities;
using Domain.Factories.ApplicationUsers;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Identity
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IApplicationUserReadService _service;
        private readonly IApplicationUserFactory _factory;
        private readonly IApplicationUserRepository _repository;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public RegisterCommandHandler(IApplicationUserReadService service, IApplicationUserFactory factory, 
            IApplicationUserRepository repository, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _service = service;
            _factory = factory;
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        async Task<Unit> IRequestHandler<RegisterCommand, Unit>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var (name, mail, password) = request;

            await _service.ExistsByNameAsync(name, true);
            await _service.ExistsByMailAsync(mail, true);

            var newUser = _factory.Create(name, mail);

            var passwordHash = _passwordHasher.HashPassword(newUser, password);

            newUser.SetPassword(passwordHash);

            await _repository.CreateAsync(newUser);

            return Unit.Value;
        }
    }
}
