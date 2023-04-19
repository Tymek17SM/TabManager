using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tab
{
    public record UpdateTabCommand(Guid Id, string? Name, string? Link, string? Description) : IRequest
    {
    }
}
