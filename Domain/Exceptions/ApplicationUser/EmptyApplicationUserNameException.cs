using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ApplicationUser
{
    public class EmptyApplicationUserNameException : ApplicationUserException
    {
        public EmptyApplicationUserNameException() : base("Application user name cannot be empty.")
        {

        }
    }
}
