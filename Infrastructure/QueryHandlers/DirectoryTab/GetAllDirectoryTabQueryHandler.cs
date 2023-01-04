using Application.Dto;
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

namespace Infrastructure.QueryHandlers.DirectoryTab
{
    internal sealed class GetAllDirectoryTabQueryHandler : IRequestHandler<GetAllDirectoryTabQuery, IEnumerable<DirectoryTabDto>>
    {
        private readonly DbSet<DirectoryTabReadModel> _directoryTabs;
        private readonly IMapper _mapper;

        public GetAllDirectoryTabQueryHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _directoryTabs = readDbContext.Directory;
            _mapper = mapper;
        }

        async Task<IEnumerable<DirectoryTabDto>> IRequestHandler<GetAllDirectoryTabQuery, IEnumerable<DirectoryTabDto>>.Handle(GetAllDirectoryTabQuery request, CancellationToken cancellationToken)
        {
            return await _directoryTabs.Include(di => di.TabReadModels).ProjectTo<DirectoryTabDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
