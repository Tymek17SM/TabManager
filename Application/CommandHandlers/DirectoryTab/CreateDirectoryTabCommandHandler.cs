using Application.Commands.DirectoryTab;
using Application.Dto;
using Application.Interfaces.ReadServices;
using AutoMapper;
using Domain.Factories.DirectoryTabs;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.DirectoryTab
{
    internal sealed class CreateDirectoryTabCommandHandler : IRequestHandler<CreateDirectoryTabCommand, Guid>
    {
        private readonly IDirectoryTabRepository _directoryTabRepository;
        private readonly IDirectoryTabFactory _directoryTabFactory;
        private readonly IUserResolverService _userService;
        private readonly IApplicationUserRepository _applicationUserRepository;
        
        public CreateDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, 
            IDirectoryTabFactory directoryTabFactory, IUserResolverService userService,
            IApplicationUserRepository applicationUserRepository)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabFactory = directoryTabFactory;
            _userService = userService;
            _applicationUserRepository = applicationUserRepository;
        }

        async Task<Guid> IRequestHandler<CreateDirectoryTabCommand, Guid>.Handle(CreateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var userName = _userService.GetUserName();
            var userId = _userService.GetUserId();

            var user = await _applicationUserRepository.GetByIdAsync(userId);

            var dir = _directoryTabFactory.Create(request.Name, user, userName);

            await _directoryTabRepository.AddAsync(dir);

            return (Guid)dir.Id;
        }
    }
}
