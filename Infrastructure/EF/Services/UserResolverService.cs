using Application.Interfaces.ReadServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Services
{
    public sealed class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(_context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public string GetUserName()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }
    }
}
