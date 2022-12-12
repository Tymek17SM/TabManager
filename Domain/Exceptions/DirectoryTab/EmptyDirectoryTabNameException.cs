using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Directory
{
    public class EmptyDirectoryTabNameException : DirectoryTabException
    {
        public EmptyDirectoryTabNameException() : base("Directory name cannot be empty.")
        {
                
        }
    }
}
