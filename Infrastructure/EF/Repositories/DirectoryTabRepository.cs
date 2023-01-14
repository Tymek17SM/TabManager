using Domain.Entities;
using Domain.Factories.DirectoryTabs;
using Domain.Interfaces;
using Domain.ValueObjects.Directory;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repositories
{
    internal sealed class DirectoryTabRepository : IDirectoryTabRepository
    {
        private readonly DbSet<DirectoryTab> _directoryTabs;
        private readonly WriteDbContext _context;
        public DirectoryTabRepository(WriteDbContext context)
        {
            _directoryTabs = context.Directory;
            _context = context;
        }

        public async Task<IEnumerable<DirectoryTab>> GetAllAsync(DirectoryTabId directoryId)
        {
            return await _directoryTabs.ToListAsync();
        }

        public async Task<DirectoryTab> GetByIdAsync(DirectoryTabId directoryTabId)
        {
            return await _directoryTabs.FirstOrDefaultAsync(tab => tab.Id == directoryTabId);
        }

        public async Task AddAsync(DirectoryTab newDirectoryTab)
        {
            await _directoryTabs.AddAsync(newDirectoryTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(DirectoryTab updatedDirectoryTab)
        {
            _directoryTabs.Update(updatedDirectoryTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(DirectoryTab deletedDirectoryTab)
        {
            _directoryTabs.Remove(deletedDirectoryTab);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
