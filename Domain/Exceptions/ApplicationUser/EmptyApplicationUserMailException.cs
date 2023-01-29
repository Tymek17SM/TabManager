using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ApplicationUser
{
    public class EmptyApplicationUserMailException : ApplicationUserException
    {
        public EmptyApplicationUserMailException() : base("Application user mail cannot be empty.")
        {

        }
    }
}
