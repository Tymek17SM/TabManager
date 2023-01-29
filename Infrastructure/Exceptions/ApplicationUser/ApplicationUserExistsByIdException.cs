using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.ApplicationUser
{
    internal class ApplicationUserExistsByIdException : ApplicationUserException
    {
        public ApplicationUserExistsByIdException() 
            : base("Application user does not exists.")
        {
                
        }
    }
}
