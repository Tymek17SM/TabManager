using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Identity
{
    public record LoginCommand(string name, string password) : IRequest<string>
    {
    }
}
