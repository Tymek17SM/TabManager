using Application.Commands.Tab;
using AutoMapper;
using Domain.Factories;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    public class UpdateTabCommandHandler : IRequestHandler<UpdateTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly IMapper _mapper;

        public UpdateTabCommandHandler(ITabRepository tabRepository, IMapper mapper)
        {
            _tabRepository = tabRepository;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<UpdateTabCommand, Unit>.Handle(UpdateTabCommand request, CancellationToken cancellationToken)
        {
            var (Id, Name, Link, Description) = request;

            var tab = await _tabRepository.GetByIdAsync(Id);

            tab.Update(Name, Link, Description);

            await _tabRepository.UpdateAsync(tab);

            return await Unit.Task;
        }
    }
}
