using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Tabs
{
    public interface ITabFactory
    {
        Tab Create(string Name, string Link, string Description);
        Tab Create(string Name, string Link, string Description, DirectoryTab directoryTab);
    }
}
