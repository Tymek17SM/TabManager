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
        public DirectoryTab Create(string Name)
        {
            return new DirectoryTab(
                Guid.NewGuid(),
                Name,
                DateTime.Now,
                "Uzyszkodnik");
        }
    }
}
