﻿using Domain.ValueObjects.Directory;
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
        private readonly ICollection<Tab> _tabs = new List<Tab>();
        private DirectoryTabAuditable _auditable;
        //Zdjecie

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

        public void SetSubordinateDirectory(DirectoryTabId directoryId)
        {
            //
        }

        public void SetSuperiorDirectory(DirectoryTabId directoryId)
        {
            //
            if(this._mainDirectory == true)
            {
                throw new Exception("TEST TEST MAIN TEST");
            }
        }
    }
}
