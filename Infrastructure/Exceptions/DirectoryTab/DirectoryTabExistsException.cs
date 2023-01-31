using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.DirectoryTab
{
    internal class DirectoryTabExistsException : DirectoryTabException
    {
        public DirectoryTabExistsException(Guid Id) : base($"Does not exists DirectoryTab with Id: {Id}")
        {

        }
    }
}
