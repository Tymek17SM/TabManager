using Application.Commands.Tab;
using Application.Interfaces.ReadServices;
using AutoMapper;
using Domain.Factories;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    internal sealed class UpdateTabCommandHandler : IRequestHandler<UpdateTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly ITabReadService _tabReadService;
        private readonly IUserResolverService _userResolverService;
        private readonly IApplicationUserReadService _applicationUserReadService;

        public UpdateTabCommandHandler(ITabRepository tabRepository,
            ITabReadService tabReadService, IUserResolverService userResolverService,
            IApplicationUserReadService applicationUserReadService)
        {
            _tabRepository = tabRepository;
            _tabReadService = tabReadService;
            _userResolverService = userResolverService;
            _applicationUserReadService = applicationUserReadService;
        }

        async Task IRequestHandler<UpdateTabCommand>.Handle(UpdateTabCommand request, CancellationToken cancellationToken)
        {
            var (tabIdFromRequest, Name, Link, Description) = request;
            var userIdFromToken = _userResolverService.GetUserId();

            await _tabReadService.ExistsByIdAsync(tabIdFromRequest, true);

            await _applicationUserReadService.ExistsByIdAsync(userIdFromToken, true);

            await _tabReadService.UserOwnerTab(tabIdFromRequest, userIdFromToken, true);

            var tab = await _tabRepository.GetByIdAsync(tabIdFromRequest);

            tab.Update(Name, Link, Description);

            await _tabRepository.UpdateAsync(tab);
        }
    }
}
