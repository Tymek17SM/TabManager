using Application.Dto;
using Application.Queries.Tab;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public GetAllTabQueryHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _tabs = readDbContext.Tabs;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TabDto>> Handle(GetAllTabQuery request, CancellationToken cancellationToken)
        {
            return await _tabs
                .Include(tab => tab.DirectoryTab)
                .ProjectTo<TabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
