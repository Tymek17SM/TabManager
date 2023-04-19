using Application.Commands.DirectoryTab;
using Application.Interfaces.ReadServices;
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
    internal sealed class MoveDirectoryTabCommandHandler
        : IRequestHandler<MoveDirectoryTabCommand>
    {
        private readonly IDirectoryTabReadService _service;
        private readonly IDirectoryTabRepository _repository;
        private readonly IUserResolverService _userResolverService;

        public MoveDirectoryTabCommandHandler(
            IDirectoryTabReadService service, 
            IDirectoryTabRepository repository,
            IUserResolverService userResolverService
            )
        {
            _service = service;
            _repository = repository;
            _userResolverService = userResolverService;
        }

        async Task IRequestHandler<MoveDirectoryTabCommand>.Handle(MoveDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (SuperiorDirectoryId, SubordinateDirectoryId) = request;

            var userIdFromToken = _userResolverService.GetUserId();

            await _service.ExistsByIdAsync(SuperiorDirectoryId);
            await _service.ExistsByIdAsync(SubordinateDirectoryId);

            await _service.UserOwnerDirectoryTab(SuperiorDirectoryId, userIdFromToken, true);
            await _service.UserOwnerDirectoryTab(SubordinateDirectoryId, userIdFromToken, true);

            var superiorDirectoryTab = await _repository.GetByIdAsync(SuperiorDirectoryId);
            var subordinateDirectoryTab = await _repository.GetByIdAsync(SubordinateDirectoryId);

            await _service.MainDirectoryTab(subordinateDirectoryTab.Id, true);

            superiorDirectoryTab.AddSubordinateDirectory(subordinateDirectoryTab);

            await _repository.UpdateAsync(superiorDirectoryTab);
        }
    }
}
