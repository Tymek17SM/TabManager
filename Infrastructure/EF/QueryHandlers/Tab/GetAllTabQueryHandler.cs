using Application.Dto;
using Application.Interfaces.ReadServices;
using Application.Queries.Tab;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.QueryHandlers.Tab
{
    internal sealed class GetAllTabQueryHandler : IRequestHandler<GetAllTabQuery, IEnumerable<TabDto>>
    {
        private readonly DbSet<TabReadModel> _tabs;
        private readonly IMapper _mapper;
        private readonly IUserResolverService _userResolverService;

        public GetAllTabQueryHandler(ReadDbContext readDbContext, IMapper mapper, IUserResolverService userResolverService)
        {
            _tabs = readDbContext.Tabs;
            _mapper = mapper;
            _userResolverService = userResolverService;
        }

        public async Task<IEnumerable<TabDto>> Handle(GetAllTabQuery request, CancellationToken cancellationToken)
        {
            var userId = _userResolverService.GetUserId();

            var dbQuery = _tabs
                .Include(tab => tab.Owner)
                .Include(tab => tab.DirectoryTab)
                .Where(tab => tab.Owner.Id == userId)
                .AsQueryable();

            if (request.searchPchrase is not null)
            {
                dbQuery = dbQuery
                    .Where(tab => Microsoft.EntityFrameworkCore.EF.Functions.Like(tab.Name, $"%{request.searchPchrase}%")
                    || Microsoft.EntityFrameworkCore.EF.Functions.Like(tab.Description, $"%{request.searchPchrase}%"));
            }

            return await dbQuery
                .ProjectTo<TabDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
