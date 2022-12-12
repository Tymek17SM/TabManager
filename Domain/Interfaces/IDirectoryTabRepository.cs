using Domain.Entities;
using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDirectoryTabRepository
    {
        Task<IEnumerable<>> GetAllFromDirectoryAsync(DirectoryTabId directoryId);
        Task<Tab> GetByIdAsync(DirectoryTabId directoryTabId);
        Task AddAsync(DirectoryTab newDirectoryTab);
        Task UpdateAsync(DirectoryTab updatedDirectoryTab);
        Task DeleteAsync(DirectoryTab deletedDirectoryTab);
    }
}
