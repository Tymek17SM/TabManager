using Application.Commands.Tab;
using Application.Interfaces.ReadServices;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    internal sealed class DeleteTabCommandHandler : IRequestHandler<DeleteTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly ITabReadService _tabReadService;
        private readonly IUserResolverService _userResolverService;
        private readonly IApplicationUserReadService _applicationUserReadService;

        public DeleteTabCommandHandler(ITabRepository tabRepository, 
            ITabReadService tabReadService, IUserResolverService userResolverService,
            IApplicationUserReadService applicationUserReadService)
        {
            _tabRepository = tabRepository;
            _tabReadService = tabReadService;
            _userResolverService = userResolverService;
            _applicationUserReadService = applicationUserReadService;
        }

        async Task IRequestHandler<DeleteTabCommand>.Handle(DeleteTabCommand request, CancellationToken cancellationToken)
        {
            var userIdFromToken = _userResolverService.GetUserId();

            await _tabReadService.ExistsByIdAsync(request.Id, true);

            await _applicationUserReadService.ExistsByIdAsync(userIdFromToken, true);

            await _tabReadService.UserOwnerTab(request.Id, userIdFromToken, true);

            var tab = await _tabRepository.GetByIdAsync(request.Id);

            await _tabRepository.DeleteAsync(tab);
        }
    }
}
