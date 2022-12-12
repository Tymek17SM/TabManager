using Domain.Exceptions.DirectoryTab;
using Domain.ValueObjects.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DirectoryTab
    {
        public DirectoryTabId Id { get; init; }

        private DirectoryTabName _directoryName;
        private bool _mainDirectory { get; init; }
        private DirectoryTabId _superiorDirectoryId { get; init; }
        private DirectoryTabId _subordinateDirectoryId { get; init; }

        private readonly List<Tab> _tabs = new();
        private DirectoryTabAuditable _auditable;
        

        public DirectoryTab(DirectoryTabId id, DirectoryTabName directoryName, DirectoryTabAuditable auditable)
        {
            Id = id;
            _directoryName = directoryName;
            _auditable = auditable;
        }

        public void AddTabToDirectory(Tab tab)
        {
            _tabs.Add(tab);
        }

        public void RemoveTabFromDirectory(Tab tab)
        {
            var tabExists = _tabs.Exists(t => t.Id == tab.Id);

            if (!tabExists)
            {
                throw new DirectoryTabTabExistsException(this._directoryName);
            }

            _tabs.Remove(tab);
        }
    }
}
