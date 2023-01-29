using Domain.Entities;
using Domain.ValueObjects.ApplicationUser;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IApplicationUserRepository : IRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(ApplicationUserId id);
        Task CreateAsync(ApplicationUser applicationUser);
        Task UpdateAsync(ApplicationUser applicationUser);
        Task DeleteAsync(ApplicationUser applicationUser);
    }
}
