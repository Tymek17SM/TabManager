using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Identity
{
    public record RegisterCommand(string name, string email, string password) : IRequest
    {
    }
}
