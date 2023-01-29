using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ApplicationUser
{
    public class EmptyApplicationUserIdException : ApplicationUserException
    {
        public EmptyApplicationUserIdException() : base("Application User Id cannot be empty.")
        {

        }
    }
}
