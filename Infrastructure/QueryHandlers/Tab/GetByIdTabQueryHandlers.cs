using Application.Dto;
using Application.Interfaces.ReadServices;
using Application.Queries.Tab;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.QueryHandlers.Tab
{
    internal sealed class GetByIdTabQueryHandlers : IRequestHandler<GetByIdTabQuery, TabDto>
    {
        private readonly DbSet<TabReadModel> _tabs;
        private readonly IMapper _mapper;
        private readonly ITabReadService _tabReadService;

        public GetByIdTabQueryHandlers(ReadDbContext readDbContext, IMapper mapper, ITabReadService tabReadService)
        {
            _tabs = readDbContext.Tabs;
            _mapper = mapper;
            _tabReadService = tabReadService;
        }

        public async Task<TabDto> Handle(GetByIdTabQuery request, CancellationToken cancellationToken)
        {
            bool tabExists = await _tabReadService.ExistsById(request.id);

            if (!tabExists)
                throw new Exception("Tab NIE MA");

#pragma warning disable CS8603 // Possible null reference return.

            return await _tabs
                .Where(tab => tab.Id == request.id)
                .ProjectTo<TabDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
