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
    internal sealed class GetAllDirectoryTabQueryHandler : IRequestHandler<GetAllDirectoryTabQuery, IEnumerable<DirectoryTabDto>>
    {
        private readonly DbSet<DirectoryTabReadModel> _directoryTabs;
        private readonly IMapper _mapper;
        private readonly IUserResolverService _userResolverService;

        public GetAllDirectoryTabQueryHandler(ReadDbContext readDbContext, IMapper mapper, IUserResolverService userResolverService)
        {
            _directoryTabs = readDbContext.Directory;
            _mapper = mapper;
            _userResolverService = userResolverService;
        }

        async Task<IEnumerable<DirectoryTabDto>> IRequestHandler<GetAllDirectoryTabQuery, IEnumerable<DirectoryTabDto>>.Handle(GetAllDirectoryTabQuery request, CancellationToken cancellationToken)
        {
            var userId = _userResolverService.GetUserId();

            var dbQuery = _directoryTabs
                .Include(dir => dir.Owner)
                .Include(dir => dir.Tabs)
                .Where(dir => dir.Owner.Id == userId)
                .AsQueryable();

            if(request.searchPchrase is not null)
            {
                dbQuery = dbQuery
                    .Where(dir => !dir.MainDirectory)
                    .Where(dir => Microsoft.EntityFrameworkCore.EF.Functions.Like(dir.Name, $"%{request.searchPchrase}%"));
            }
            else
            {
                dbQuery = dbQuery
                    .Where(dir => dir.MainDirectory);
            }

            return await dbQuery
                .ProjectTo<DirectoryTabDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
