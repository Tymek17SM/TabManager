using Application.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tab
{
    public record CreateTabCommand(string Name, string Link, string Description, Guid DirectoryTabId) : IRequest
    {

    }
}
