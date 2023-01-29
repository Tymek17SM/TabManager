using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.ApplicationUser
{
    internal class ApplicationUserExistsByNameException : ApplicationUserException
    {
        public ApplicationUserExistsByNameException(bool exists) 
            : base(exists ? "Already exists user with the same name." : "Application user does not exists.")
        {

        }
    }
}
