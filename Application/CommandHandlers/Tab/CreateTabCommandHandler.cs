using Application.Commands.Tab;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Factories.Tabs;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    internal sealed class CreateTabCommandHandler : IRequestHandler<CreateTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly IDirectoryTabRepository _directoryTababRepository;
        private readonly ITabFactory _tabFactory;
        private readonly IMapper _mapper;

        public CreateTabCommandHandler(ITabRepository tabRepository, IDirectoryTabRepository directoryTababRepository, ITabFactory tabFactory, IMapper mapper)
        {
            _tabRepository = tabRepository;
            _directoryTababRepository = directoryTababRepository;
            _tabFactory = tabFactory;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<CreateTabCommand, Unit>.Handle(CreateTabCommand request, CancellationToken cancellationToken)
        {
            var (name, link, description, id) = request;

            if (id is not null)
            {
                var directory = await _directoryTababRepository.GetByIdAsync(id);
                if(directory is null)
                {
                    throw new Exception("TEST");
                }

                var newTabWithId = _tabFactory.Create(name, link, description, directory);
                await _tabRepository.AddAsync(newTabWithId);
            }
            else
            {
                var newTab = _tabFactory.Create(name, link, description);

                await _tabRepository.AddAsync(newTab);
            }

            return Unit.Value;
        }
    }
}
