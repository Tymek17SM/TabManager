using Application.Interfaces.ReadServices;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using Infrastructure.Exceptions;
using Infrastructure.Exceptions.DirectoryTab;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Services
{
    internal sealed class DirectoryTabReadService : IDirectoryTabReadService
    {
        private readonly DbSet<DirectoryTabReadModel> _directoryTab;
        private readonly ReadDbContext _context;

        public DirectoryTabReadService(ReadDbContext readDbContext, ReadDbContext context)
        {
            _directoryTab = readDbContext.Directory;
            _context = context;
        }

        public async Task<bool> ExistsByIdAsync(Guid Id, bool withException = false)
        {
            return await _directoryTab.AnyAsync(dir => dir.Id == Id)
                || (withException ? throw new DirectoryTabExistsException(Id) : false);
        }

        public async Task<bool> UserOwnerDirectoryTab(Guid directoryTabId, Guid userId, bool withException = false)
        {
            await this.ExistsByIdAsync(directoryTabId, true);

            var directoryTab = await _context.Directory.Include(dir => dir.Owner)
                .SingleOrDefaultAsync(dir => dir.Id == directoryTabId);

            if (directoryTab.Owner.Id == userId)
                return true;
            else
                return withException ? throw new DirectoryTabOwnerException() : false;
        }

        public async Task<bool> MainDirectoryTab(Guid directoryTabId, bool withException = false)
        {
            await this.ExistsByIdAsync(directoryTabId, true);

            var directoryTab = await _directoryTab.SingleOrDefaultAsync(dir => dir.Id == directoryTabId);

            return directoryTab.MainDirectory ? throw new MainDirectoryTabException() : false;
        }
    }
}
