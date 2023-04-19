using Application.Commands.Tab;
using Application.Dto;
using Application.Interfaces.ReadServices;
using AutoMapper;
using Domain.Entities;
using Domain.Factories.Tabs;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    internal sealed class CreateTabCommandHandler : IRequestHandler<CreateTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly ITabReadService _tabReadService;
        private readonly ITabFactory _tabFactory;
        private readonly IDirectoryTabReadService _directoryTabReadService;
        private readonly IDirectoryTabRepository _directoryTababRepository;
        private readonly IUserResolverService _userResolverService;
        private readonly IApplicationUserReadService _applicationUserReadService;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public CreateTabCommandHandler(ITabRepository tabRepository, 
            IDirectoryTabRepository directoryTababRepository, ITabFactory tabFactory,
            IUserResolverService userResolverService, ITabReadService tabReadService,
            IDirectoryTabReadService directoryTabReadService, IApplicationUserReadService applicationUserReadService,
            IApplicationUserRepository applicationUserRepository)
        {
            _tabRepository = tabRepository;
            _directoryTababRepository = directoryTababRepository;
            _tabFactory = tabFactory;
            _userResolverService = userResolverService;
            _tabReadService = tabReadService;
            _directoryTabReadService = directoryTabReadService;
            _applicationUserReadService = applicationUserReadService;
            _applicationUserRepository = applicationUserRepository;
        }

        async Task IRequestHandler<CreateTabCommand>.Handle(CreateTabCommand request, CancellationToken cancellationToken)
        {
            var (tabNameFromRequest, linkFromRequest, tabDescriptionFromRequest, directoryTabIdFromRequest) = request;

            var userIdFromToken = _userResolverService.GetUserId();
            var userNameFromToken = _userResolverService.GetUserName();

            await _applicationUserReadService.ExistsByIdAsync(userIdFromToken, true);

            var user = await _applicationUserRepository.GetByIdAsync(userIdFromToken);

            bool toMainDirectoryTab = true;

            if (directoryTabIdFromRequest != Guid.Empty)
            {
                await _directoryTabReadService.ExistsByIdAsync(directoryTabIdFromRequest, true);
                toMainDirectoryTab = false;
            }

            var directoryTabId = toMainDirectoryTab
                ? await _applicationUserReadService.GetUserMainDirectoryTabId(_userResolverService.GetUserId())
                : directoryTabIdFromRequest;

            var directoryTab = await _directoryTababRepository.GetByIdAsync(directoryTabId);

            var newTab = _tabFactory.Create(
                tabNameFromRequest,
                linkFromRequest,
                tabDescriptionFromRequest,
                directoryTab,
                user,
                userNameFromToken);

            await _tabRepository.AddAsync(newTab);
        }
    }
}
