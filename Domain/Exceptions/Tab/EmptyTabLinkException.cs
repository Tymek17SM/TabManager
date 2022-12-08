using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabLinkException : TabException
    {
        public EmptyTabLinkException() : base("Tab link cannot be empty.")
        {

        }
    }
}
