using Domain.Entities;
using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDirectoryTabRepository : IRepository
    {
        Task<IEnumerable<DirectoryTab>> GetAllAsync(DirectoryTabId directoryId);
        Task<DirectoryTab> GetByIdAsync(DirectoryTabId directoryTabId);
        Task AddAsync(DirectoryTab newDirectoryTab);
        Task UpdateAsync(DirectoryTab updatedDirectoryTab);
        Task DeleteAsync(DirectoryTab deletedDirectoryTab);
    }
}
