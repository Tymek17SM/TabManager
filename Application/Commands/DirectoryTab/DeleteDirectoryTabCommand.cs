﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DirectoryTab
{
    public record DeleteDirectoryTabCommand(Guid Id) : IRequest
    {
    }
}
