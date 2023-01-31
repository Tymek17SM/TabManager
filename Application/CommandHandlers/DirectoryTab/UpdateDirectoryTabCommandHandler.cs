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
            await _directoryTabReadService.ExistsByIdAsync(request.Id, true);

            var directoryTab = await _directoryTabRepository.GetByIdAsync(request.Id);

            await _directoryTabReadService.UserOwnerDirectoryTab(directoryTab.Id, _userResolverService.GetUserId(), true);

            directoryTab.EditName(request.Name);

            await _directoryTabRepository.UpdateAsync(directoryTab);

            return Unit.Value;
        }
    }
}
