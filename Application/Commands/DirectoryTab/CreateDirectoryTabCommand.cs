using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DirectoryTab
{
    public record CreateDirectoryTabCommand(string Name, Guid SuperiorDirectoryTabId) : IRequest<Guid>
    {

    }
}
