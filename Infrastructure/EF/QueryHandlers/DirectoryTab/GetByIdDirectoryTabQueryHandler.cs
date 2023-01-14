using Application.Dto;
using Application.Interfaces.ReadServices;
using Application.Queries.DirectoryTab;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.QueryHandlers.DirectoryTab
{
    internal sealed class GetByIdDirectoryTabQueryHandler : IRequestHandler<GetByIdDirectoryTabQuery, DirectoryTabDto>
    {
        private readonly DbSet<DirectoryTabReadModel> _directoryTabs;
        private readonly IMapper _mapper;
        private readonly IDirectoryTabReadService _directoryTabReadService;

        public GetByIdDirectoryTabQueryHandler(ReadDbContext readDbContext, IMapper mapper, IDirectoryTabReadService directoryTabReadService)
        {
            _directoryTabs = readDbContext.Directory;
            _mapper = mapper;
            _directoryTabReadService = directoryTabReadService;
        }

        async Task<DirectoryTabDto> IRequestHandler<GetByIdDirectoryTabQuery, DirectoryTabDto>.Handle(GetByIdDirectoryTabQuery request, CancellationToken cancellationToken)
        {
            await _directoryTabReadService.ExistsByIdAsync(request.id, true);

            #pragma warning disable CS8603 // Possible null reference return.

            return await _directoryTabs
                .Where(dir => dir.Id == request.id)
                .ProjectTo<DirectoryTabDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
