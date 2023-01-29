using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ApplicationUser
{
    public class ApplicationUserCreatedException : ApplicationUserException
    {
        public ApplicationUserCreatedException() : base("Application user created date exception.")
        {

        }
    }
}
