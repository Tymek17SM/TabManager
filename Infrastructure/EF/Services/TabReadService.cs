using Application.Interfaces.ReadServices;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using Infrastructure.Exceptions;
using Infrastructure.Exceptions.Tab;
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

        public async Task<bool> ExistsByIdAsync(Guid tabId, bool withException = false)
        {
            //---TEST---
            //var test = _context.Model.ToDebugString();
            //using StreamWriter file = new("C:\\Users\\Tymek\\Desktop\\ReadModelAuto.txt", append:false, Encoding.Unicode);
            //await file.WriteAsync(test);

            return await _tabs.AnyAsync(tab => tab.Id == tabId) == true
                || (withException == true ? throw new TabExistsException(tabId) : false);
        }

        public async Task<bool> UserOwnerTab(Guid tabId, Guid userId, bool withException = false)
        {
            var tab = await _context.Tabs
                .Include(tab => tab.Owner)
                .SingleOrDefaultAsync(tab => tab.Id == tabId);

            return tab.Owner.Id == userId
                ? true
                : withException ? throw new TabOwnerException() : false;
        }
    }
}
