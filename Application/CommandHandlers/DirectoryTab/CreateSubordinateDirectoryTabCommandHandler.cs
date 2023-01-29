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
        private readonly IUserResolverService _userResolverService;
        private readonly IApplicationUserRepository _applicationuserRepository;

        public CreateSubordinateDirectoryTabCommandHandler(
            IDirectoryTabReadService service,
            IDirectoryTabRepository repository,
            IDirectoryTabFactory factory,
            IUserResolverService userResolverService,
            IApplicationUserRepository applicationUserRepository
            )
        {
            _service = service;
            _repository = repository;
            _factory = factory;
            _userResolverService = userResolverService;
            _applicationuserRepository = applicationUserRepository;
        }

        async Task<Guid> IRequestHandler<CreateSubordinateDirectoryTabCommand, Guid>.Handle(CreateSubordinateDirectoryTabCommand request, CancellationToken cancellationToken)
        {
            var (id, name) = request;

            await _service.ExistsByIdAsync(id, true);

            var directory = await _repository.GetByIdAsync(id);

            var userName = _userResolverService.GetUserName();
            var userId = _userResolverService.GetUserId();

            var user = await _applicationuserRepository.GetByIdAsync(userId);

            var newDirectory = _factory.Create(name, user, userName);

            directory.AddSubordinateDirectory(newDirectory);

            await _repository.UpdateAsync(directory);

            return newDirectory.Id;
        }
    }
}
