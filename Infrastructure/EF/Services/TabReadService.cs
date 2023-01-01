using Application.Interfaces.ReadServices;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Services
{
    internal sealed class TabReadService : ITabReadService
    {
        private readonly DbSet<TabReadModel> _tabs;
        private readonly ReadDbContext _context;

        public TabReadService(ReadDbContext readDbContext, ReadDbContext context)
        {
            _tabs = readDbContext.Tabs;
            _context = context;
        }

        public async Task<bool> ExistsById(Guid tabId)
        {
            var test = _context.Model.ToDebugString();
            return await _tabs.AnyAsync(tab => tab.Id == tabId);
        }
    }
}
