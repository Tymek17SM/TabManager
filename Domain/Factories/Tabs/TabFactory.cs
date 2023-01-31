using Domain.Entities;
using Domain.ValueObjects.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Tabs
{
    internal sealed class TabFactory : ITabFactory
    {

        public Tab Create(string Name, string Link, string Description, DirectoryTab directoryTab, ApplicationUser owner, string userName)
        {
            return new Tab(
                Guid.NewGuid(), 
                Name, 
                Link, 
                Description,
                directoryTab,
                DateTime.Now,
                userName,
                owner);
        }
    }
}
