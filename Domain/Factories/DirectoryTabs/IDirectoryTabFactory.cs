using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.DirectoryTabs
{
    public interface IDirectoryTabFactory
    {
        DirectoryTab Create(string Name);
    }
}
