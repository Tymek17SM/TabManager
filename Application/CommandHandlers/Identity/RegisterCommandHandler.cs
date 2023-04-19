using Application.Commands.Identity;
using Application.Interfaces.ReadServices;
using Domain.Entities;
using Domain.Factories.ApplicationUsers;
using Domain.Factories.DirectoryTabs;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly IDirectoryTabReadService _directoryTabReadService;
        private readonly IDirectoryTabRepository _directoryTabRepository;
        private readonly IDirectoryTabFactory _directoryTabFactory;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(IApplicationUserReadService service, IApplicationUserFactory factory, 
            IApplicationUserRepository repository, IPasswordHasher<ApplicationUser> passwordHasher,
            IDirectoryTabReadService directoryTabReadService, IDirectoryTabRepository directoryTabRepository,
            IDirectoryTabFactory directoryTabFactory, ILogger<RegisterCommandHandler> logger)
        {
            _service = service;
            _factory = factory;
            _repository = repository;
            _passwordHasher = passwordHasher;
            _directoryTabReadService = directoryTabReadService;
            _directoryTabRepository = directoryTabRepository;
            _directoryTabFactory = directoryTabFactory;
            _logger = logger;
        }

        async Task IRequestHandler<RegisterCommand>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var (name, mail, password) = request;

            await _service.ExistsByNameAsync(name, true);
            await _service.ExistsByMailAsync(mail, true);

            var newUser = _factory.Create(name, mail);

            var passwordHash = _passwordHasher.HashPassword(newUser, password);

            newUser.SetPassword(passwordHash);

            await _repository.CreateAsync(newUser);

            var userMainDirectory = _directoryTabFactory.CreateMainDirectory(newUser, name);

            await _directoryTabRepository.AddAsync(userMainDirectory);

            _logger.LogInformation($"New user {newUser.Id} registered successfully.");
        }
    }
}
