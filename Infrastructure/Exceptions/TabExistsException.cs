using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    internal class TabExistsException : TabException
    {
        public TabExistsException(Guid Id) : base($"Does not exists Tab with Id: {Id}")
        {

        }
    }
}
