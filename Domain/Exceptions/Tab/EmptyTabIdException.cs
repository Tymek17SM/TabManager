using Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabIdException : TabException
    {
        public EmptyTabIdException() : base("Tab id cannot be empty.")
        {

        }
    }
}
