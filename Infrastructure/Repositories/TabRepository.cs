﻿using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class TabRepository : ITabRepository
    {
        private readonly DbSet<Tab> _tabs;
        private readonly WriteDbContext _context;

        public TabRepository(WriteDbContext context)
        {
            _tabs = context.Tabs;
            _context = context;
        }

        public async Task<IEnumerable<Tab>> GetAllFromDirectoryAsync(DirectoryTabId directoryId)
        {
            return await _tabs.ToListAsync();
        }

        public async Task<Tab> GetByIdAsync(TabId tabId)
        {
            return await _tabs.SingleOrDefaultAsync(tab => tab.Id == tabId);
        }

        public async Task AddAsync(Tab newTab)
        {
            var test = _context.Model.ToDebugString();
            Console.WriteLine("");
            await _tabs.AddAsync(newTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Tab updatedTab)
        {
            _tabs.Update(updatedTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Tab deletedTab)
        {
            _tabs.Remove(deletedTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
