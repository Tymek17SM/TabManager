using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Tab
{
    internal class TabOwnerException : TabException
    {
        public TabOwnerException() : base("You do not own this tab!")
        {

        }
    }
}
