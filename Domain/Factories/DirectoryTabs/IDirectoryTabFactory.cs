using Domain.Entities;
using Domain.Interfaces;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.DirectoryTabs
{
    public interface IDirectoryTabFactory : IFactory
    {
        DirectoryTab Create(string directoryTabName, ApplicationUser owner, string ownerName);

        DirectoryTab CreateMainDirectory(ApplicationUser owner, string ownerName);
    }
}
