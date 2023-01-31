using Domain.Exceptions.DirectoryTab;
using Domain.ValueObjects.Directory;
using Shared.Abstractions.Auditables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DirectoryTab : AggregateRoot
    {
        public DirectoryTabId Id { get; private set; }

        private DirectoryTabName _directoryName;
        private bool _mainDirectory;
        private DirectoryTabId? _superiorDirectoryId;
        private ApplicationUser _owner;

        private readonly List<DirectoryTab> _subordinateDirectories = new();

        private readonly List<Tab> _tabs = new();

        private DirectoryTab()
        {

        }

        internal DirectoryTab(DirectoryTabId id, DirectoryTabName directoryName, DateTime created, string createdBy, 
            ApplicationUser owner)
        {
            Id = id;
            _directoryName = directoryName;
            _created = created;
            _createdBy = createdBy;
            _owner = owner;
        }

        internal DirectoryTab(DirectoryTabId id, DirectoryTabName directoryName, DateTime created, string createdBy,
            ApplicationUser owner, bool mainDirectory = false)
        {
            Id = id;
            _directoryName = directoryName;
            _created = created;
            _createdBy = createdBy;
            _owner = owner;
            _mainDirectory = mainDirectory;
        }

        public void AddTabToDirectory(Tab tab)
        {
            _tabs.Add(tab);
        }

        public void AddSubordinateDirectory(DirectoryTab subordinateDirectory) 
        {
            _subordinateDirectories.Add(subordinateDirectory);
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

        public void EditName(DirectoryTabName Name)
        {
            _directoryName = Name;
        }
    }
}
