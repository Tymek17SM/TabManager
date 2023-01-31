using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.DirectoryTabs
{
    internal sealed class DirectoryTabFactory : IDirectoryTabFactory
    {
        DirectoryTab IDirectoryTabFactory.Create(string directoryTabName, ApplicationUser owner, string ownerName)
        {
            return new DirectoryTab(
                Guid.NewGuid(),
                directoryTabName,
                DateTime.Now,
                ownerName,
                owner);
        }

        DirectoryTab IDirectoryTabFactory.CreateMainDirectory(ApplicationUser owner, string ownerName)
        {
            return new DirectoryTab(
                Guid.NewGuid(),
                $"Main_{ownerName}_{owner.Id.Value}",
                DateTime.Now,
                ownerName,
                owner,
                true);
        }
    }
}
