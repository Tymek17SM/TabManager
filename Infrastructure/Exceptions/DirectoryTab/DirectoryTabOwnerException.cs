using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.DirectoryTab
{
    internal class DirectoryTabOwnerException : DirectoryTabException
    {
        public DirectoryTabOwnerException() : base("You do not own this directory!")
        {

        }
    }
}
