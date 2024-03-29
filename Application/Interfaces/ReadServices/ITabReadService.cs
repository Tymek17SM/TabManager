﻿using Shared.Abstractions.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReadServices
{
    public interface ITabReadService : IApplicationReadService
    {
        Task<bool> ExistsByIdAsync(Guid tabId, bool withException = false);
        Task<bool> UserOwnerTab(Guid tabId, Guid userId, bool withException = false);
    }
}
