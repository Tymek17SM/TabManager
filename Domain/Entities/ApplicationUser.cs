using Domain.ValueObjects.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Abstractions.Auditables;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser : AggregateRoot
    {
        public ApplicationUserId Id { get; private set; }

        private ApplicationUserName _name;
        private ApplicationUserMail _mail;
        private ApplicationUserPasswordHash _passwordHash;

        private readonly List<DirectoryTab> _directoryTabs = new();

        private ApplicationUser()
        {

        }

        internal ApplicationUser(ApplicationUserId id, ApplicationUserName name, ApplicationUserMail mail, 
            DateTime created, string createdBy)
        {
            Id = id;
            _name = name;
            _mail = mail;
            _created = created;
            _createdBy = createdBy;
        }

        internal List<Claim> GetClaims()
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Id.Value.ToString()),
                new Claim(ClaimTypes.Name, _name)
            };
        }

        public PasswordVerificationResult VerifyPassword(IPasswordHasher<ApplicationUser> passwordHasher, string password)
        {
            return passwordHasher.VerifyHashedPassword(this, _passwordHash, password);
        }

        public void SetPassword(ApplicationUserPasswordHash passwordHash) 
        {
            _passwordHash = passwordHash;
        }
    }
}
