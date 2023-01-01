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
    internal sealed class DirectoryTabReadService : IDirectoryTabReadService
    {
        private readonly DbSet<DirectoryTabReadModel> _directoryTab;
        public DirectoryTabReadService(ReadDbContext readDbContext)
        {
            _directoryTab = readDbContext.Directory;
        }

        public async Task<bool> ExistsByIdAsync(Guid Id)
        {
            return await _directoryTab.AnyAsync(dir => dir.Id == Id);
        }
    }
}
