using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.ApplicationUser
{
    public class ApplicationUserExistsByMailException : ApplicationUserException
    {
        public ApplicationUserExistsByMailException() : base("Already exists user with the same mail.")
        {

        }
    }
}
