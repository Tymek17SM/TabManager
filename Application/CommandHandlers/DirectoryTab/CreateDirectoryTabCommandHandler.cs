using Application.Commands.DirectoryTab;
using Application.Dto;
using AutoMapper;
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
    public class CreateDirectoryTabCommandHandler : IRequestHandler<CreateDirectoryTabCommand, Guid>
    {
        private readonly IDirectoryTabRepository _directoryTabRepository;
        private readonly IDirectoryTabFactory _directoryTabFactory;
        
        public CreateDirectoryTabCommandHandler(IDirectoryTabRepository directoryTabRepository, IDirectoryTabFactory directoryTabFactory, IMapper mapper)
        {
            _directoryTabRepository = directoryTabRepository;
            _directoryTabFactory = directoryTabFactory;
        }

        async Task<Guid> IRequestHandler<CreateDirectoryTabCommand, Guid>.Handle(CreateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var dir = _directoryTabFactory.Create(request.Name);

            await _directoryTabRepository.AddAsync(dir);

            return (Guid)dir.Id;
        }
    }
}
