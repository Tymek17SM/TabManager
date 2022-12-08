﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Abstractions.Exceptions
{
    public abstract class DirectoryTabException : Exception
    {
        public DirectoryTabException(string? message) : base(message)
        {

        }
    }
}
