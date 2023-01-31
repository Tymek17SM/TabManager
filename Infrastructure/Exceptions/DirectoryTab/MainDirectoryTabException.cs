using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.DirectoryTab
{
    internal class MainDirectoryTabException : DirectoryTabException
    {
        public MainDirectoryTabException() : base("You can not do this action on main directory!")
        {

        }
    }
}
