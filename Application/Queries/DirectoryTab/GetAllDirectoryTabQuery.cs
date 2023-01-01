using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DirectoryTab
{
    public record GetAllDirectoryTabQuery : IRequest<IEnumerable<DirectoryTabDto>>
    {
    }
}
