﻿using Shared.Abstractions.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReadServices
{
    public interface IDirectoryTabReadService : IApplicationReadService
    {
        Task<bool> ExistsByIdAsync(Guid Id, bool withException = false);
        Task<bool> UserOwnerDirectoryTab(Guid directoryTabId, Guid userId, bool withException = false);
        Task<bool> MainDirectoryTab(Guid directoryTabId, bool withException = false);
    }
}
