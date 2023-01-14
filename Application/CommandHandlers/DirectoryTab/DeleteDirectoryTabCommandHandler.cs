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

        public DeleteDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, IDirectoryTabReadService directoryTabReadService)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabReadService = directoryTabReadService;
        }

        async Task<Unit> IRequestHandler<DeleteDirectoryTabCommand, Unit>.Handle(DeleteDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var dirExusts = await _directoryTabReadService.ExistsByIdAsync(request.Id);

            if(!dirExusts)
            {
                throw new Exception("Test!");
            }

            var dir = await _directoryTabRepository.GetByIdAsync(request.Id);

            await _directoryTabRepository.DeleteAsync(dir);
            return Unit.Value;
        }
    }
}
