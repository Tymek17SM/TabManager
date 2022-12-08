using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabNameException : TabException
    {
        public EmptyTabNameException() : base("Tab name cannot be empty.")
        {

        }
    }
}
