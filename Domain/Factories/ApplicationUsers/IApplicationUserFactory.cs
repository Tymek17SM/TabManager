using Domain.Entities;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.ApplicationUsers
{
    public interface IApplicationUserFactory : IFactory
    {
        ApplicationUser Create(string name, string email);
    }
}
