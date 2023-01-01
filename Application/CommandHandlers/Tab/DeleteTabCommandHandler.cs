using Application.Commands.Tab;
using Application.Interfaces.ReadServices;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Tab
{
    public class DeleteTabCommandHandler : IRequestHandler<DeleteTabCommand>
    {
        private readonly ITabRepository _tabRepository;
        private readonly ITabReadService _tabReadService;

        public DeleteTabCommandHandler(ITabRepository tabRepository, ITabReadService tabReadService)
        {
            _tabRepository = tabRepository;
            _tabReadService = tabReadService;
        }

        async Task<Unit> IRequestHandler<DeleteTabCommand, Unit>.Handle(DeleteTabCommand request, CancellationToken cancellationToken)
        {
            var tabExists = await _tabReadService.ExistsById(request.Id);

            if (!tabExists)
            {
                throw new Exception("TTTT");
            }

            var tab = await _tabRepository.GetByIdAsync(request.Id);
            await _tabRepository.DeleteAsync(tab);

            return Unit.Value;
        }
    }
}
