using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DirectoryTab
{
    public record MoveDirectoryTabCommand(Guid SuperiorDirectoryId, Guid SubordinateDirectoryId) : IRequest
    {
    }
}
