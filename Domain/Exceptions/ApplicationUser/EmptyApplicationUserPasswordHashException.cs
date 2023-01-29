using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ApplicationUser
{
    public class EmptyApplicationUserPasswordHashException : ApplicationUserException
    {
        public EmptyApplicationUserPasswordHashException() : base("Application user password hash cannot be empty.")
        {

        }
    }
}
