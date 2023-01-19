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
    internal sealed class CreateSubordinateDirectoryTabCommandHandler 
        : IRequestHandler<CreateSubordinateDirectoryTabCommand, Guid>
    {
        private readonly IDirectoryTabReadService _service;
        private readonly IDirectoryTabRepository _repository;
        private readonly IDirectoryTabFactory _factory;

        public CreateSubordinateDirectoryTabCommandHandler(
            IDirectoryTabReadService service,
            IDirectoryTabRepository repository,
            IDirectoryTabFactory factory)
        {
            _service = service;
            _repository = repository;
            _factory = factory;
        }

        async Task<Guid> IRequestHandler<CreateSubordinateDirectoryTabCommand, Guid>.Handle(CreateSubordinateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (id, name) = request;

            await _service.ExistsByIdAsync(id, true);

            var directory = await _repository.GetByIdAsync(id);

            var newDirectory = _factory.Create(name);

            directory.AddSubordinateDirectory(newDirectory);

            await _repository.UpdateAsync(directory);

            return newDirectory.Id;
        }
    }
}
