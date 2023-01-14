using Domain.Entities;
using Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Tabs
{
    public interface ITabFactory : IFactory
    {
        Tab Create(string Name, string Link, string Description);
        Tab Create(string Name, string Link, string Description, DirectoryTab directoryTab);
    }
}
