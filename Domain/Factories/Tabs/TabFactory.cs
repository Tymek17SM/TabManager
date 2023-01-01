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
    public sealed class TabFactory : ITabFactory
    {
        public Tab Create(string Name, string Link, string Description)
        {
            return new Tab(Guid.NewGuid(), Name, Link, Description, DateTime.Now, "Uzyszkodnik");
        }

        public Tab Create(string Name, string Link, string Description, DirectoryTab directoryTab)
        {
            return new Tab(Guid.NewGuid(), Name, Link, Description, directoryTab, DateTime.Now, "Uzyszkodnik");
        }
    }
}
