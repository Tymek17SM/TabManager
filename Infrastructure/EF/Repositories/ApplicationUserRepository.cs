using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects.ApplicationUser;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repositories
{
    internal class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly DbSet<ApplicationUser> _users;
        private readonly WriteDbContext _context;

        public ApplicationUserRepository(WriteDbContext context)
        {
            _users = context.ApplicationUsers;
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _users.ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(ApplicationUserId id)
        {
            #pragma warning disable CS8603 // Possible null reference return.

            return await _users.Where(u => u.Id == id).SingleOrDefaultAsync();

            #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task CreateAsync(ApplicationUser applicationUser)
        {
            _users.Add(applicationUser);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            _users.Update(applicationUser);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(ApplicationUser applicationUser)
        {
            _users.Remove(applicationUser);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
