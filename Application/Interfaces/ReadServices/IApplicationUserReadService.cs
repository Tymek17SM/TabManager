using Shared.Abstractions.Application;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReadServices
{
    public interface IApplicationUserReadService : IApplicationReadService
    {
        Task<bool> ExistsByIdAsync(Guid id, bool withException = false);
        Task<bool> ExistsByNameAsync(string name, bool exists, bool withException = false);
        Task<bool> ExistsByMailAsync(string mail, bool withException = false);
        Task<Guid> GetIdByNameAsync(string name);
        Task<Guid> GetUserMainDirectoryTabId(Guid userId);
    }
}
