using Application.Interfaces.ReadServices;
using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using Infrastructure.EF.Options;
using Infrastructure.Exceptions.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Services
{
    internal sealed class ApplicationUserReadService : IApplicationUserReadService
    {
        private readonly DbSet<ApplicationUserReadModel> _users;
        private readonly ReadDbContext _context;
        private readonly IConfiguration _configuration;

        public ApplicationUserReadService(ReadDbContext context, IConfiguration configuration)
        {
            _users = context.ApplicationUsers;
            _context = context;
            _configuration = configuration;
        }

        async Task<bool> IApplicationUserReadService.ExistsByIdAsync(Guid id, bool withException)
        {
            return await _users.AnyAsync(u => u.Id == id)
                || (withException ? throw new ApplicationUserExistsByIdException() : false);
        }

        async Task<bool> IApplicationUserReadService.ExistsByNameAsync(string name, bool exists, bool withException)
        {
            return await _users.AnyAsync(u => u.Name == name) == exists
                ? exists
                : (withException ? throw new ApplicationUserExistsByNameException(!exists) : !exists);
        }

        async Task<bool> IApplicationUserReadService.ExistsByMailAsync(string mail, bool withException)
        {
            return await _users.AnyAsync(u => u.Mail == mail)
                ? (withException ? throw new ApplicationUserExistsByMailException() : true)
                : false;
        }

        async Task<Guid> IApplicationUserReadService.GetIdByNameAsync(string name)
        {
            var user = await _users.SingleOrDefaultAsync(u => u.Name == name);
            return user.Id;
        }

        async Task<Guid> IApplicationUserReadService.GetUserMainDirectoryTabId(Guid userId)
        {
            var users = _context.ApplicationUsers.Include(u => u.DirectoryTabs);

            var user = await users.Where(u => u.Id == userId).SingleOrDefaultAsync();
            
            return user.DirectoryTabs.Where(dir => dir.MainDirectory).SingleOrDefault().Id;
        }
    }
}
