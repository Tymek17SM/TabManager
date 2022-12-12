using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Directory
{
    public class EmptyDirectoryTabIdException : DirectoryTabException
    {
        public EmptyDirectoryTabIdException() : base("Directory Id cannot be empty!")
        {

        }
    }
}
