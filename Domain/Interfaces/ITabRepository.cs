using Domain.Entities;
using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using Shared.Abstractions.Domain;

namespace Domain.Interfaces
{
    public interface ITabRepository : IRepository
    {
        Task<IEnumerable<Tab>> GetAllFromDirectoryAsync(DirectoryTabId directoryId);
        Task<Tab> GetByIdAsync(TabId tabId);
        Task AddAsync(Tab newTab);
        Task UpdateAsync(Tab updatedTab);
        Task DeleteAsync(Tab deletedTab);
    }
}
