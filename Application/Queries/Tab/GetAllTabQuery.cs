﻿using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tab
{
    public record GetAllTabQuery(string? searchPchrase) : IRequest<IEnumerable<TabDto>>
    {
    }
}
