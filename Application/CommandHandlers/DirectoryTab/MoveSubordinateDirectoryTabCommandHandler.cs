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
    internal sealed class MoveSubordinateDirectoryTabCommandHandler
        : IRequestHandler<MoveSubordinateDirectoryTabCommand>
    {
        private readonly IDirectoryTabReadService _service;
        private readonly IDirectoryTabRepository _repository;

        public MoveSubordinateDirectoryTabCommandHandler(
            IDirectoryTabReadService service, 
            IDirectoryTabRepository repository
            )
        {
            _service = service;
            _repository = repository;
        }

        async Task<Unit> IRequestHandler<MoveSubordinateDirectoryTabCommand, Unit>.Handle(MoveSubordinateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (SuperiorDirectoryId, SubordinateDirectoryId) = request;

            await _service.ExistsByIdAsync(SuperiorDirectoryId);
            await _service.ExistsByIdAsync(SubordinateDirectoryId);

            var superiorDirectoryTab = await _repository.GetByIdAsync(SuperiorDirectoryId);
            var subordinateDirectoryTab = await _repository.GetByIdAsync(SubordinateDirectoryId);

            superiorDirectoryTab.AddSubordinateDirectory(subordinateDirectoryTab);

            await _repository.UpdateAsync(superiorDirectoryTab);

            return Unit.Value;
        }
    }
}
