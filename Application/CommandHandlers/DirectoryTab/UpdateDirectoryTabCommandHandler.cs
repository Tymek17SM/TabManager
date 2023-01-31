using Application.Commands.DirectoryTab;
using Application.Interfaces.ReadServices;
using AutoMapper.Configuration.Annotations;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.DirectoryTab
{
    internal sealed class UpdateDirectoryTabCommandHandler : IRequestHandler<UpdateDirectoryTabCommand>
    {
        private readonly IDirectoryTabRepository _directoryTabRepository;
        private readonly IDirectoryTabReadService _directoryTabReadService;
        private readonly IUserResolverService _userResolverService;

        public UpdateDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, 
            IDirectoryTabReadService directoryTabReadService, IUserResolverService userResolverService)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabReadService = directoryTabReadService;
            _userResolverService = userResolverService;
        }

        async Task<Unit> IRequestHandler<UpdateDirectoryTabCommand, Unit>.Handle(UpdateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (directoryTabIdFromRequest, newNameFromRequest) = request;

            await _directoryTabReadService.ExistsByIdAsync(directoryTabIdFromRequest, true);

            await _directoryTabReadService.UserOwnerDirectoryTab(directoryTabIdFromRequest, _userResolverService.GetUserId(), true);

            var directoryTab = await _directoryTabRepository.GetByIdAsync(directoryTabIdFromRequest);

            directoryTab.EditName(newNameFromRequest);

            await _directoryTabRepository.UpdateAsync(directoryTab);

            return Unit.Value;
        }
    }
}
