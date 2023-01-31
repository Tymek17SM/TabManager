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
        private readonly IDirectoryTabReadService _directoryTabReadService;
        private readonly IUserResolverService _userResolverService;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationUserReadService _applicationUserReadService;
        
        public CreateDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, 
            IDirectoryTabFactory directoryTabFactory, IDirectoryTabReadService directoryTabReadService,
            IUserResolverService userResolverService, IApplicationUserRepository applicationUserRepository, 
            IApplicationUserReadService applicationUserReadService)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabFactory = directoryTabFactory;
            _directoryTabReadService = directoryTabReadService;
            _userResolverService = userResolverService;
            _applicationUserRepository = applicationUserRepository;
            _applicationUserReadService = applicationUserReadService;
        }

        async Task<Guid> IRequestHandler<CreateDirectoryTabCommand, Guid>.Handle(CreateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (directoryTabNameFromRequest, SuperiorDirectoryTabIdFromRequest) = request;

            var userNameFromToken = _userResolverService.GetUserName();
            var userIdFromToken = _userResolverService.GetUserId();

            var applicationUser = await _applicationUserRepository.GetByIdAsync(userIdFromToken);

            bool toMainDirectoryTab = true;

            if(SuperiorDirectoryTabIdFromRequest != Guid.Empty)
            {
                await _directoryTabReadService.ExistsByIdAsync(SuperiorDirectoryTabIdFromRequest, true);
                toMainDirectoryTab = false;
            }

            var newDirectoryTab = _directoryTabFactory.Create(directoryTabNameFromRequest, applicationUser, userNameFromToken);

            var superiorDirectoryTabId = toMainDirectoryTab
                ? await _applicationUserReadService.GetUserMainDirectoryTabId(applicationUser.Id)
                : SuperiorDirectoryTabIdFromRequest;

            var superiorDirectoryTab = await _directoryTabRepository.GetByIdAsync(superiorDirectoryTabId);

            superiorDirectoryTab.AddSubordinateDirectory(newDirectoryTab);

            await _directoryTabRepository.AddAsync(newDirectoryTab);

            return (Guid)newDirectoryTab.Id;
        }
    }
}
