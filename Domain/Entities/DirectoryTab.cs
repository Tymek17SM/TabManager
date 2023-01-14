﻿using Domain.Exceptions.DirectoryTab;
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
        private DirectoryTabId? _subordinateDirectoryId;

        private readonly List<Tab> _tabs = new();

        private DirectoryTab()
        {

        }

        internal DirectoryTab(DirectoryTabId id, DirectoryTabName directoryName, DateTime created, string createdBy)
        {
            Id = id;
            _directoryName = directoryName;
            _created = created;
            _createdBy = createdBy;
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

        public void EditName(DirectoryTabName Name)
        {
            _directoryName = Name;
        }
    }
}
