using Application.Commands.DirectoryTab;
using Application.Interfaces.ReadServices;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.DirectoryTab
{
    internal sealed class DeleteDirectoryTabCommandHandler : IRequestHandler<DeleteDirectoryTabCommand>
    {
        private readonly IDirectoryTabRepository _directoryTabRepository;
        private readonly IDirectoryTabReadService _directoryTabReadService;
        private readonly IUserResolverService _userResolverService;

        public DeleteDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, 
            IDirectoryTabReadService directoryTabReadService, IUserResolverService userResolverService)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabReadService = directoryTabReadService;
            _userResolverService = userResolverService;
        }

        async Task IRequestHandler<DeleteDirectoryTabCommand>.Handle(DeleteDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            await _directoryTabReadService.ExistsByIdAsync(request.Id, true);

            await _directoryTabReadService.UserOwnerDirectoryTab(request.Id, _userResolverService.GetUserId(), true);

            var dir = await _directoryTabRepository.GetByIdAsync(request.Id);

            await _directoryTabReadService.MainDirectoryTab(dir.Id, true);

            await _directoryTabRepository.DeleteAsync(dir);
        }
    }
}
