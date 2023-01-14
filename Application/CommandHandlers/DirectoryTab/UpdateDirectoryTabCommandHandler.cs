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

        public UpdateDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, IDirectoryTabReadService directoryTabReadService)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabReadService = directoryTabReadService;
        }

        async Task<Unit> IRequestHandler<UpdateDirectoryTabCommand, Unit>.Handle(UpdateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var directoryTabExists = await _directoryTabReadService.ExistsByIdAsync(request.Id);

            if (!directoryTabExists)
            {
                throw new Exception("Test!");
            }

            var dir = await _directoryTabRepository.GetByIdAsync(request.Id);

            dir.EditName(request.Name);

            await _directoryTabRepository.UpdateAsync(dir);

            return Unit.Value;
        }
    }
}
