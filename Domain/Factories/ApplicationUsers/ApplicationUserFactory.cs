using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.ApplicationUsers
{
    internal sealed class ApplicationUserFactory : IApplicationUserFactory
    {
        ApplicationUser IApplicationUserFactory.Create(string name, string email)
        {
            return new(Guid.NewGuid(),
                name,
                email, 
                DateTime.Now,
                "Uzyszkodnik");
        }
    }
}
